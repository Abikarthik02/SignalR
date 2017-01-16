using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace SignalR
{
    public class RealTimeDataHub : Hub
    {
        public void GetUsers()
        {
            List<UserModel> _lst = new List<UserModel>();
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SampleDBEntity"].ConnectionString))
            {
                String query = "SELECT Id, FirstName, LastName, Address FROM [dbo].[User]";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Notification = null;
                    DataTable dt = new DataTable();
                    SqlDependency dependency = new SqlDependency(command);

                    dependency.OnChange += dependency_OnChange;

                    if (connection.State == ConnectionState.Closed) connection.Open();

                    SqlDependency.Start(connection.ConnectionString);
                    var reader = command.ExecuteReader();
                    dt.Load(reader);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            _lst.Add(new UserModel
                            {
                                Id = Int32.Parse(dt.Rows[i]["Id"].ToString()),
                                FirstName = dt.Rows[i]["FirstName"].ToString(),
                                LastName = dt.Rows[i]["LastName"].ToString(),
                                Address = dt.Rows[i]["Address"].ToString()
                            });
                        }
                    }
                }
            }
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<RealTimeDataHub>();
            context.Clients.All.displayUsers(_lst);
        }

        void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Type == SqlNotificationType.Change)
            {
                RealTimeDataHub _dataHub = new RealTimeDataHub();
                _dataHub.GetUsers();
            }
        }
    }
}
