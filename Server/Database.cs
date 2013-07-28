using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Oracle.DataAccess.Types;


namespace Server
{
    [Serializable()]
    public class Database
    {
        public string user;
        public string pass;
        public string host;

        public static string oradb;

        public Database()
        {
            if (File.Exists("db.bin"))
            {
                Stream fs = File.OpenRead("db.bin");
                BinaryFormatter deserializer = new BinaryFormatter();
                Database db = (Database)deserializer.Deserialize(fs);
                fs.Close();

                user = db.user;
                host = db.host;
                pass = db.pass;

                oradb = "Data Source=" + host + ";User Id=" + user + ";Password=" + pass + ";";
            }
        }


        /// <summary>
        /// Reinstallation of the database
        /// </summary>
        public void ReInstallDatabase()
        {

            //createDatabase();
            Console.WriteLine("Starting");
            OracleConnection conn = CreateConnection();

            DropTables(conn);
            CreateTables(conn);


            conn.Close();
            conn.Dispose();
            Console.Write("Finished");
        }


        /// <summary>
        /// Installs Database
        /// </summary>
        public void InstallDatabase()
        {

            //createDatabase();
            Console.WriteLine("Starting");
            OracleConnection conn = CreateConnection();

            CreateTables(conn);

            conn.Close();
            conn.Dispose();
            Console.Write("Finished");
        }


        /// <summary>
        /// Uninstalls Database
        /// </summary>
        public void UninstallDatabase()
        {

            //createDatabase();
            Console.WriteLine("Starting");
            OracleConnection conn = CreateConnection();


            DropTables(conn);


            conn.Close();
            conn.Dispose();
            Console.Write("Finished");
            Console.ReadLine();
        }


        /// <summary>
        /// Creates the tables required for new
        /// installation of the program
        /// </summary>
        /// <param name="conn"></param>
        public static void CreateTables(OracleConnection conn)
        {
            string sql = null;

            try
            {
                sql = @"create sequence group_seq start with 1 increment by 1 nomaxvalue";

                OracleCommand createGroupSeq = new OracleCommand(sql, conn);


                createGroupSeq.CommandType = CommandType.Text;

                OracleDataReader dr = createGroupSeq.ExecuteReader();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                sql = @"Create table SystemComponents(
                            SYSID varchar(100),
                            CPU varchar(100),
                            RAM varchar(100),
                            MOTHERBOARD varchar(100),
                            STORAGE varchar(100),
                            DISPLAY varchar(100),
                            PRIMARY KEY(SYSID)
                            )";
                OracleCommand createTable = new OracleCommand(sql, conn);


                createTable.CommandType = CommandType.Text;

                OracleDataReader dr = createTable.ExecuteReader();
            }
            catch (OracleException oe)
            {
                Console.WriteLine(sql + ": " + oe.Message);
            }

            try
            {
                sql = @"Create table PROC(
                            NAME varchar(100),
                            PRIMARY KEY(NAME)
                            )";
                OracleCommand createTable = new OracleCommand(sql, conn);

                createTable.CommandType = CommandType.Text;

                OracleDataReader dr = createTable.ExecuteReader();
            }
            catch (OracleException oe)
            {
                Console.WriteLine(sql + ": " + oe.Message);
            }

            try
            {
                sql = @"CREATE table COMPUTERUPTIME(
                        COMPID VARCHAR(100),
                        TWENTYFOURHOURS VARCHAR(255),
                        SEVENDAYS VARCHAR(255),
                        THIRTYDAYS VARCHAR(255),
                        FIRSTUPDATE TIMESTAMP,
                        LASTUPDATE TIMESTAMP,
                        PRIMARY KEY (COMPID)
                    )";

                OracleCommand createTable = new OracleCommand(sql, conn);


                createTable.CommandType = CommandType.Text;

                OracleDataReader dr = createTable.ExecuteReader();
            }
            catch (OracleException oe)
            {
                Console.WriteLine(sql + ": " + oe.Message);
            }

            try
            {
                sql = @"Create table ComputerGroup(
                            GROUPID varchar(100),
                            GROUPNAME varchar(255),
                            GROUPDESCRIPTION varchar(255),
                            PRIMARY KEY(GROUPID)
                            )";
                OracleCommand createTable = new OracleCommand(sql, conn);


                createTable.CommandType = CommandType.Text;

                OracleDataReader dr = createTable.ExecuteReader();
            }
            catch (OracleException oe)
            {
                Console.WriteLine(sql + ": " + oe.Message);
            }


            try
            {
                sql = @"Create table COMPPROC(
                            COMPID varchar(100),
                            NAME varchar(100),
                            CONSTRAINT PK_COMPPROC PRIMARY KEY(CompID, NAME)
                            )";
                OracleCommand createTable = new OracleCommand(sql, conn);

                createTable.CommandType = CommandType.Text;

                OracleDataReader dr = createTable.ExecuteReader();
            }
            catch (OracleException oe)
            {
                Console.WriteLine(sql + ": " + oe.Message);
            }

            try
            {
                sql = @"Create table computer(
                            COMPID varchar(100),
                            OS varchar(100),
                            COMPNAME varchar(100),
                            GROUPID varchar(100),
                            SYSID varchar(100),
                            MAC varchar(255),
                            PRIMARY KEY(COMPID),
                            FOREIGN KEY(GROUPID) REFERENCES ComputerGroup,
                            FOREIGN KEY(SYSID) REFERENCES SystemComponents
                            )";
                OracleCommand createTable = new OracleCommand(sql, conn);


                createTable.CommandType = CommandType.Text;

                OracleDataReader dr = createTable.ExecuteReader();
            }
            catch (OracleException oe)
            {
                Console.WriteLine(sql + ": " + oe.Message);
            }
        }


        /// <summary>
        /// Create a new data connection
        /// </summary>
        /// <returns>An Oracle Data Connection</returns>
        private static OracleConnection CreateConnection()
        {
            try
            {
                OracleConnection conn = new OracleConnection(oradb);
                conn.Open();
                return conn;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new OracleConnection();
            }

        }

        /// <summary>
        /// Closes a data connection
        /// </summary>
        /// <param name="conn">The data connection to close</param>
        private static void CloseConnection(OracleConnection conn)
        {
            conn.Close();
            conn.Dispose();
        }

        /// <summary>
        /// Drops tables
        /// Used for program installation/uninstallation
        /// </summary>
        /// <param name="conn">The connection to use</param>
        private static void DropTables(OracleConnection conn)
        {
            string sql = null;

            try
            {
                sql = @"drop table COMPPROC";
                OracleCommand dropTable = new OracleCommand(sql, conn);
                dropTable.CommandType = CommandType.Text;
                OracleDataReader dr = dropTable.ExecuteReader();
                Console.WriteLine(sql + " executed successfully");

            }
            catch (OracleException oe)
            {
                Console.WriteLine(sql + " " + oe.Message);
            }

            try
            {
                sql = @"drop table COMPUTERUPTIME";
                OracleCommand dropTable = new OracleCommand(sql, conn);
                dropTable.CommandType = CommandType.Text;
                OracleDataReader dr = dropTable.ExecuteReader();
                Console.WriteLine(sql + " executed successfully");

            }
            catch (OracleException oe)
            {
                Console.WriteLine(sql + " " + oe.Message);
            }

            try
            {
                sql = @"drop table PROC";
                OracleCommand dropTable = new OracleCommand(sql, conn);
                dropTable.CommandType = CommandType.Text;
                OracleDataReader dr = dropTable.ExecuteReader();
                Console.WriteLine(sql + " executed successfully");

            }
            catch (OracleException oe)
            {
                Console.WriteLine(sql + " " + oe.Message);
            }

            try
            {
                sql = @"drop table computer";
                OracleCommand dropTable = new OracleCommand(sql, conn);
                dropTable.CommandType = CommandType.Text;
                OracleDataReader dr = dropTable.ExecuteReader();
                Console.WriteLine(sql + " executed successfully");

            }
            catch (OracleException oe)
            {
                Console.WriteLine(sql + " " + oe.Message);
            }

            try
            {
                sql = @"drop table systemcomponents";
                OracleCommand dropTable = new OracleCommand(sql, conn);
                dropTable.CommandType = CommandType.Text;
                OracleDataReader dr = dropTable.ExecuteReader();
                Console.WriteLine(sql + " executed successfully");
            }
            catch (OracleException oe)
            {
                Console.WriteLine(sql + " " + oe.Message);
            }

            try
            {
                sql = @"drop table computergroup";
                OracleCommand dropTable = new OracleCommand(sql, conn);
                dropTable.CommandType = CommandType.Text;
                OracleDataReader dr = dropTable.ExecuteReader();
                Console.WriteLine(sql + " executed successfully");

            }
            catch (OracleException oe)
            {
                Console.WriteLine(sql + " " + oe.Message);
            }


        }

        public void AddProcesses(string compid, List<string> procnames)
        {
            OracleConnection conn = CreateConnection();
            string sql = null;

            foreach (string proc in procnames)
            {
                Console.WriteLine("Adding To System Components");
                try
                {

                    sql = "INSERT INTO PROC(NAME)values(:procname)";


                    OracleCommand cmd = new OracleCommand(sql, conn);


                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(":procname", proc);

                    cmd.ExecuteNonQuery();
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                try
                {
                    sql = "INSERT INTO COMPPROC(COMPID, NAME)values(:compid, :procname)";


                    OracleCommand cmd = new OracleCommand(sql, conn);


                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(":compid", compid.Trim());
                    cmd.Parameters.Add(":procname", proc);
                    

                    cmd.ExecuteNonQuery();
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            
        }

        public void InsertIntoTable(string table, string[] data)
        {
            Console.WriteLine("Adding To Database");
            OracleConnection conn = CreateConnection();
            string sql = null;
            if (table.ToUpper().Trim() == "SYSTEMCOMPONENTS")
            {

                Console.WriteLine("Adding To System Components");
                try
                {

                    sql = "INSERT INTO " + table + "(SYSID, CPU, RAM, MOTHERBOARD, STORAGE, DISPLAY)values(:sysid,:cpu,:ram,:mobo, :storage,:display)";


                    OracleCommand cmd = new OracleCommand(sql, conn);


                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(":sysid", "S" + data[0]);
                    cmd.Parameters.Add(":cpu", data[1]);
                    cmd.Parameters.Add(":ram", data[2]);
                    cmd.Parameters.Add(":mobo", data[3]);
                    cmd.Parameters.Add(":storage", data[4]);
                    cmd.Parameters.Add(":display", data[5]);


                    cmd.ExecuteNonQuery();
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            else if (table.ToUpper().Trim() == "COMPUTERGROUP")
            {
                Console.WriteLine("Adding To Computer Group");
                try
                {
                    /*GROUPID	VARCHAR2(100)	No	 -	1
                    GROUPNAME	VARCHAR2(255)	Yes	 -	 -
                    GROUPDESCRIPTION	VARCHAR2(255)	Yes	 -	 -*/
                    sql = "INSERT INTO " + table + "(GROUPID, GROUPNAME, GROUPDESCRIPTION)values(group_seq.nextval,:gn,:gc)";


                    OracleCommand cmd = new OracleCommand(sql, conn);


                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(":gn", data[0]);
                    cmd.Parameters.Add(":gc", data[1]);


                    cmd.ExecuteNonQuery();
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            else if (table.ToUpper().Trim() == "COMPUTER")
            {
                Console.WriteLine("Adding To Computer");
                try
                {

                    sql = "INSERT INTO " + table + "(COMPID, SYSID, OS, COMPNAME, MAC)values (:compid,:sysid, :osname,:compname,:macid)";


                    OracleCommand cmd = new OracleCommand(sql, conn);


                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(":compid", data[0]);
                    cmd.Parameters.Add(":sysid", "S" + data[0]);
                    cmd.Parameters.Add(":osname", data[2]);
                    cmd.Parameters.Add(":compname", data[1]);
                    cmd.Parameters.Add(":macid", data[3]);


                    cmd.ExecuteNonQuery();


                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Something went wrong");
            }

            conn.Close();
        }

        public bool CheckForNewComputer(string compid)
        {

            try
            {
                OracleConnection conn = CreateConnection();

                string sql = "select * from COMPUTER"
                   + " where COMPID = '" + compid + @"'";

                OracleCommand cmd = new OracleCommand(sql, conn);

                OracleDataReader dr = cmd.ExecuteReader();


                bool exists = dr.HasRows;

                dr.Dispose();
                conn.Close();

                return exists;


            }
            catch (System.Exception ex)
            {
                return false;
                Console.WriteLine(ex.Message);
            }


        }

        public List<Group> GetGroups()
        {
            List<Group> groups = new List<Group>();

            try
            {
                OracleConnection conn = CreateConnection();



                string sql = "Select * from COMPUTERGROUP";

                OracleCommand cmd = new OracleCommand(sql, conn);

                OracleDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    groups.Add(new Group(dr["GROUPID"].ToString().Trim(), dr["GROUPNAME"].ToString().Trim(), dr["GROUPDESCRIPTION"].ToString().Trim()));
                }

                dr.Dispose();
                conn.Close();

                return groups;


            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Group>();

            }

        }

        private static void GetComputer()
        {
        }

        private static void GetOperations()
        {
        }

        public void AddToGroup(string compid, string groupid)
        {
            try
            {
                OracleConnection conn = CreateConnection();

                string sql = "UPDATE COMPUTER SET GROUPID = '" + groupid.Trim() + "' WHERE COMPID = '" + compid.Trim() + "'";

                OracleCommand cmd = new OracleCommand(sql, conn);

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public string GetClientGroup(string compid)
        {
            try
            {
                OracleConnection conn = CreateConnection();

                string sql = "SELECT GROUPID FROM COMPUTER WHERE COMPID = '" + compid.Trim() + "'";

                OracleCommand cmd = new OracleCommand(sql, conn);

                OracleDataReader dr = cmd.ExecuteReader();

                dr.Read();

                return dr.GetString(0);

                conn.Close();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "nogroup";
            }
            

        }



        private static void RemoveFromGroup()
        {
        }

        private static void RemoveGroup()
        {
        }


        public void SetDetails(string user, string host, string pass)
        {
            this.user = user;
            this.pass = pass;
            this.host = host;
            oradb = "Data Source= " + host + ";User Id=" + user + ";Password=" + pass + ";";
        }

        public string GetUser()
        {
            return user;
        }

        public string GetPass()
        {
            return pass;
        }

        public string GetHost()
        {
            return host;
        }

        public bool CheckConnection()
        {


            try
            {
                OracleConnection conn = CreateConnection();
                CloseConnection(conn);
                return true;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message + " " + oradb);
                return false;
            }



        }


        public List<string[]> GetKnownClients()
        {

            try
            {
                List<string[]> compDetails = new List<string[]>();
                OracleConnection conn = CreateConnection();



                string sql = "Select * from COMPUTER";

                OracleCommand cmd = new OracleCommand(sql, conn);

                OracleDataReader dr = cmd.ExecuteReader();


                int count = 0;
                while (dr.Read())
                {
                    string[] details = new string[6];
                    details[0] = dr["COMPID"].ToString();
                    details[1] = dr["OS"].ToString();
                    details[2] = dr["COMPNAME"].ToString();
                    details[3] = dr["GROUPID"].ToString();
                    details[4] = dr["SYSID"].ToString();
                    details[5] = dr["MAC"].ToString();
                    compDetails.Add(details);
                }

                dr.Dispose();
                conn.Close();

                return compDetails;


            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                List<string[]> noDetails = new List<string[]>();
                return noDetails;
                Console.WriteLine(ex.Message);
            }
        }

        public List<string> GetProcesses(string compid)
        {

            try
            {
                List<string> proclist = new List<string>();
                OracleConnection conn = CreateConnection();



                string sql = "Select NAME from COMPPROC WHERE COMPID = '" + compid +"'";

                OracleCommand cmd = new OracleCommand(sql, conn);

                OracleDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    proclist.Add(dr["NAME"].ToString().Trim());
                }

                dr.Dispose();
                conn.Close();

                return proclist.Distinct().ToList();


            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                List<string> noDetails = new List<string>();
                return noDetails;
                Console.WriteLine(ex.Message);
            }
        }

        public string[] GetStats()
        {

            try
            {
                string[] stats = new string[6];
                OracleConnection conn = CreateConnection();



                string sql = "select CPU, COUNT(*) FROM SYSTEMCOMPONENTS GROUP BY CPU ORDER BY COUNT(*) DESC";

                OracleCommand cmd = new OracleCommand(sql, conn);

                OracleDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    stats[0] = dr.GetString(0).Trim();
                }


                sql = "select MOTHERBOARD, COUNT(*) FROM SYSTEMCOMPONENTS GROUP BY MOTHERBOARD ORDER BY COUNT(*) DESC";


                cmd = new OracleCommand(sql, conn);

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    stats[1] = dr.GetString(0).Trim();
                }

                sql = "select Display, COUNT(*) FROM SYSTEMCOMPONENTS GROUP BY Display ORDER BY COUNT(*) DESC";


                cmd = new OracleCommand(sql, conn);

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    stats[2] = dr.GetString(0).Trim();
                }

                sql = "SELECT AVG(RAM) AS avgram FROM systemcomponents";


                cmd = new OracleCommand(sql, conn);

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    stats[3] = dr.GetValue(0).ToString().Trim() + "MB";
                }

                sql = "SELECT AVG(storage) AS avgstorage FROM systemcomponents";


                cmd = new OracleCommand(sql, conn);

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    stats[4] = dr.GetValue(0).ToString().Trim() + "GB";
                }

                sql = "SELECT AVG(thirtydays) AS avguptime FROM computeruptime";


                cmd = new OracleCommand(sql, conn);

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    stats[5] = dr.GetValue(0).ToString().Trim() + "Hours";
                }


                dr.Dispose();


                conn.Close();

                return stats;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new string[0];
                Console.WriteLine(ex.Message);
            }
        }
        
        public void InitialSetUptimes(string compid, string uptime)
        {
            try
            {
                OracleConnection conn = CreateConnection();
                OracleTimeStamp time = DateTime.Now;

                string sql = "INSERT INTO COMPUTERUPTIME(COMPID, TWENTYFOURHOURS, SEVENDAYS, THIRTYDAYS,  FIRSTUPDATE, LASTUPDATE)values(:compid,:uptime, :sevendays, :thirtydays, :fu, :lu)";

                OracleCommand cmd = new OracleCommand(sql, conn);
                cmd.Parameters.Add(":compid", compid);
                cmd.Parameters.Add(":uptime", uptime);
                cmd.Parameters.Add(":sevendays,", uptime);
                cmd.Parameters.Add(":thirtydays", uptime);
                cmd.Parameters.Add(":fu", time);
                cmd.Parameters.Add(":lu", time);

                cmd.ExecuteNonQuery();

                conn.Close();

            }
            catch (System.Exception ex)
            {
           //"SELECT * FROM aTable WHERE someDateColumn <=  TO_DATE('" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "', 'YYYY/MM/DD')"
            }
        }
    }
}