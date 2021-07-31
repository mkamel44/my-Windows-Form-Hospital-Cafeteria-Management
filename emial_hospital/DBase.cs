using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Collections;
using System.Globalization;

namespace emial_hospital
{
    public class DBase
    {
        public static OleDbConnection createConnection()
        {

            int index = Application.ExecutablePath.LastIndexOf('\\');

            string path = Application.ExecutablePath.Substring(0, index) + "\\" + "dbase.mdb";

            OleDbConnection aConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Persist Security Info=True;Jet OLEDB:Database Password=admin123");

            aConnection.Open();

            return aConnection;

        }

        public static void addLogin(string user_id)
        {
            OleDbConnection con = createConnection();

            string uu = getMyDateWithSeconds();

            String insertSQL = "insert into user_login (user_id,login,logout) values (" + user_id + ",'" + uu + "','" + uu + "')";

            OleDbCommand command = new OleDbCommand(insertSQL, con);

            command.ExecuteNonQuery();

            con.Close();
        }

        public static void addLogout(string user_id)
        {
            OleDbConnection con = createConnection();

            String insertSQL = "update user_login set logout='" + getMyDateWithSeconds() + "' where id =" + getLastLogin(user_id);

            OleDbCommand command = new OleDbCommand(insertSQL, con);

            command.ExecuteNonQuery();

            con.Close();
        }

        public static string addM(string name, string typeme, string part_id)
        {
            OleDbConnection con = createConnection();

            String insertSQL = "insert into m (name,typeme,part_id) values ('" + name + "','" + typeme + "'," + part_id + ")";

            OleDbCommand command = new OleDbCommand(insertSQL, con);

            command.ExecuteNonQuery();

            con.Close();

            return getLastRowOFM();
        }

        public static void addM_back(string bill_id, string id, string name, string typeme, string part_id)
        {
            OleDbConnection con = createConnection();

            String insertSQL = "insert into m_back (bill_id,id,name,typeme,part_id) values (" + bill_id + "," + id + ",'" + name + "','" + typeme + "'," + part_id + ")";

            OleDbCommand command = new OleDbCommand(insertSQL, con);

            command.ExecuteNonQuery();

            con.Close();

        }

        public static string addFatoraNumber(string time)
        {
            OleDbConnection con = createConnection();

            String insertSQL = "insert into tbnum (num,datee) values ('" + time.Substring(0, time.IndexOf("-")) + "','" + time.Substring(time.IndexOf("-") + 1).Substring(0, time.Substring(time.IndexOf("-") + 1).IndexOf(" ")) + "')";

            OleDbCommand command = new OleDbCommand(insertSQL, con);

            command.ExecuteNonQuery();

            con.Close();

            return getLastRowOFM();
        }

        public static string addQCM(string qua, string cost, string m_id, string points)
        {
            OleDbConnection con = createConnection();

            String insertSQL = "insert into qcm (m_id,qua,cost,points) values (" + m_id + "," + qua + "," + cost + "," + points + ")";

            OleDbCommand command = new OleDbCommand(insertSQL, con);

            command.ExecuteNonQuery();

            con.Close();

            return getLastRowOFM();
        }

        public static void addQCM_back(string bill_id, string id, string qua, string cost, string m_id, string points)
        {
            OleDbConnection con = createConnection();

            String insertSQL = "insert into qcm_back (bill_id,id,m_id,qua,cost,points) values (" + bill_id + "," + id + "," + m_id + "," + qua + "," + cost + "," + points + ")";

            OleDbCommand command = new OleDbCommand(insertSQL, con);

            command.ExecuteNonQuery();

            con.Close();
        }

        public static string getLastRowOFM()
        {
            string lolo = "";

            OleDbConnection con = createConnection();

            String selectSQL = "SELECT max(id) as lolo FROM m";

            OleDbCommand command = new OleDbCommand(selectSQL, con);

            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                lolo = reader["lolo"].ToString();
            }

            reader.Close();

            con.Close();

            return lolo;

        }

        public static string getLastLogin(string user_id)
        {
            string lolo = "";

            OleDbConnection con = createConnection();

            String selectSQL = "SELECT max(id) as lolo FROM user_login where user_id=" + user_id;

            OleDbCommand command = new OleDbCommand(selectSQL, con);

            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                lolo = reader["lolo"].ToString();
            }

            reader.Close();

            con.Close();

            return lolo;

        }

        public static void addPart(string name, string num)
        {
            OleDbConnection con = createConnection();

            String insertSQL = "insert into parts (name,num) values ('" + name + "'," + num + ")";

            OleDbCommand command = new OleDbCommand(insertSQL, con);

            command.ExecuteNonQuery();

            con.Close();
        }

        public static void addPart1(string name, string num)
        {
            OleDbConnection con = createConnection();

            String insertSQL = "insert into parts1 (name,num) values ('" + name + "'," + num + ")";

            OleDbCommand command = new OleDbCommand(insertSQL, con);

            command.ExecuteNonQuery();

            con.Close();
        }

        public static string addBill(string num, string person_id, string opened, string user_id, string note, string note2)
        {
            OleDbConnection con = createConnection();

            String insertSQL = "insert into bill (num,person_id,opened,user_id,notee,datee,note2) values ('" + num + "'," + person_id + ",'" + opened + "'," + user_id + ",'" + note + "','" + getMyDate() + "','" + note2 + "')";

            OleDbCommand command = new OleDbCommand(insertSQL, con);

            command.ExecuteNonQuery();

            con.Close();

            return getLastRowOFBill();
        }

        public static string addBill1(string num, string person_id, string opened, string user_id, string note, string note2)
        {
            OleDbConnection con = createConnection();

            String insertSQL = "insert into bill1 (num,person_id,opened,user_id,notee,datee,note2) values ('" + num + "'," + person_id + ",'" + opened + "'," + user_id + ",'" + note + "','" + getMyDate() + "','" + note2 + "')";

            OleDbCommand command = new OleDbCommand(insertSQL, con);

            command.ExecuteNonQuery();

            con.Close();

            return getLastRowOFBill1();
        }

        public static string getLastRowOFBill()
        {
            string lolo = "";

            OleDbConnection con = createConnection();

            String selectSQL = "SELECT max(id) as lolo FROM bill";

            OleDbCommand command = new OleDbCommand(selectSQL, con);

            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                lolo = reader["lolo"].ToString();
            }

            reader.Close();

            con.Close();

            return lolo;

        }

        public static string getLastRowOFBill1()
        {
            string lolo = "";

            OleDbConnection con = createConnection();

            String selectSQL = "SELECT max(id) as lolo FROM bill1";

            OleDbCommand command = new OleDbCommand(selectSQL, con);

            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                lolo = reader["lolo"].ToString();
            }

            reader.Close();

            con.Close();

            return lolo;

        }

        public static string addBillQ(string bill_id, string req_id, string q, string cost)
        {
            OleDbConnection con = createConnection();

            String insertSQL = "insert into billq (bill_id,req_id,q,cost) values (" + bill_id + "," + req_id + "," + q + "," + cost + ")";

            OleDbCommand command = new OleDbCommand(insertSQL, con);

            command.ExecuteNonQuery();

            con.Close();

            return getLastRowOFBill();
        }

        public static string addBillQ1(string bill_id, string req_id, string q, string cost)
        {
            OleDbConnection con = createConnection();

            String insertSQL = "insert into billq1 (bill_id,req_id,q,cost) values (" + bill_id + "," + req_id + "," + q + "," + cost + ")";

            OleDbCommand command = new OleDbCommand(insertSQL, con);

            command.ExecuteNonQuery();

            con.Close();

            return getLastRowOFBill();
        }

        public static ArrayList getAllParts(string num)
        {

            ArrayList list = new ArrayList();

            OleDbConnection con = createConnection();

            String selectSQL = "SELECT * FROM parts where num=" + num + " order by id";

            OleDbCommand command = new OleDbCommand(selectSQL, con);

            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Hashtable table = new Hashtable();

                table.Add("id", reader["id"].ToString());

                table.Add("num", reader["num"]);

                table.Add("name", reader["name"]);

                list.Add(table);
            }

            reader.Close();

            con.Close();

            return list;
        }

        public static ArrayList getAllParts2()
        {

            ArrayList list = new ArrayList();

            OleDbConnection con = createConnection();

            String selectSQL = "SELECT * FROM parts order by id";

            OleDbCommand command = new OleDbCommand(selectSQL, con);

            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Hashtable table = new Hashtable();

                table.Add("id", reader["id"].ToString());

                table.Add("num", reader["num"]);

                table.Add("name", reader["name"]);

                list.Add(table);
            }

            reader.Close();

            con.Close();

            return list;
        }

        public static ArrayList getAllParts1(string num)
        {

            ArrayList list = new ArrayList();

            OleDbConnection con = createConnection();

            String selectSQL = "SELECT * FROM parts1 where num=" + num + " order by id";

            OleDbCommand command = new OleDbCommand(selectSQL, con);

            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Hashtable table = new Hashtable();

                table.Add("id", reader["id"].ToString());

                table.Add("num", reader["num"]);

                table.Add("name", reader["name"]);

                list.Add(table);
            }

            reader.Close();

            con.Close();

            return list;
        }

        public static ArrayList getAllMHader()
        {
            ArrayList list = new ArrayList();

            OleDbConnection con = createConnection();

            String selectSQL = "SELECT * FROM m where typeme='1' order by name";

            OleDbCommand command = new OleDbCommand(selectSQL, con);

            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Hashtable table = new Hashtable();

                table.Add("id", reader["id"].ToString());

                table.Add("name", reader["name"].ToString());

                table.Add("part_id", reader["part_id"].ToString());

                table.Add("typeme", reader["typeme"].ToString());

                table.Add("qcm", getAllQCMForM(reader["id"].ToString()));

                list.Add(table);
            }

            reader.Close();

            con.Close();

            return list;
        }

        public static ArrayList getAllM(string part_id)
        {
            ArrayList list = new ArrayList();

            OleDbConnection con = createConnection();

            String selectSQL = "SELECT * FROM m where part_id=" + part_id + " order by name";

            OleDbCommand command = new OleDbCommand(selectSQL, con);

            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Hashtable table = new Hashtable();

                table.Add("id", reader["id"].ToString());

                table.Add("name", reader["name"].ToString());

                table.Add("part_id", reader["part_id"].ToString());

                table.Add("typeme", reader["typeme"].ToString());

                table.Add("qcm", getAllQCMForM(reader["id"].ToString()));

                list.Add(table);
            }

            reader.Close();

            con.Close();

            return list;
        }

        public static ArrayList getAllBills(string user_id)
        {
            ArrayList list = new ArrayList();

            OleDbConnection con = createConnection();

            String selectSQL = "SELECT * FROM bill where user_id=" + user_id + " and opened='true' order by id";

            OleDbCommand command = new OleDbCommand(selectSQL, con);

            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Hashtable table = new Hashtable();

                table.Add("id", reader["id"].ToString());

                table.Add("num", reader["num"].ToString());

                table.Add("person_id", reader["person_id"].ToString());

                table.Add("user_id", reader["user_id"].ToString());

                table.Add("opened", reader["opened"].ToString());

                table.Add("datee", reader["datee"].ToString());

                table.Add("notee", reader["notee"].ToString());

                table.Add("billq", getAllBillsQ(reader["id"].ToString()));

                list.Add(table);
            }

            reader.Close();

            con.Close();

            return list;
        }

        public static ArrayList getAllBills1(string user_id)
        {
            ArrayList list = new ArrayList();

            OleDbConnection con = createConnection();

            String selectSQL = "SELECT * FROM bill1 where user_id=" + user_id + " order by id";

            OleDbCommand command = new OleDbCommand(selectSQL, con);

            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Hashtable table = new Hashtable();

                table.Add("id", reader["id"].ToString());

                table.Add("num", reader["num"].ToString());

                table.Add("person_id", reader["person_id"].ToString());

                table.Add("user_id", reader["user_id"].ToString());

                table.Add("opened", reader["opened"].ToString());

                table.Add("datee", reader["datee"].ToString());

                table.Add("notee", reader["notee"].ToString());

                table.Add("billq", getAllBillsQ1(reader["id"].ToString()));

                table.Add("note2", reader["note2"].ToString());

                list.Add(table);
            }

            reader.Close();

            con.Close();

            return list;
        }

        public static ArrayList getAllLoginUsers()
        {
            ArrayList list = new ArrayList();

            OleDbConnection con = createConnection();

            String selectSQL = "SELECT id,user_id, login,logout,(select name from users where id=user_id) as name FROM user_login order by user_id,login";

            OleDbCommand command = new OleDbCommand(selectSQL, con);

            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Hashtable table = new Hashtable();

                table.Add("id", reader["id"].ToString());

                table.Add("name", reader["name"].ToString());

                table.Add("login", reader["login"].ToString());

                table.Add("logout", reader["logout"].ToString());

                list.Add(table);
            }

            reader.Close();

            con.Close();

            return list;
        }

        public static ArrayList getAllBillByQueary(string selectSQL)
        {
            ArrayList list = new ArrayList();

            OleDbConnection con = createConnection();

            OleDbCommand command = new OleDbCommand(selectSQL, con);

            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Hashtable table = new Hashtable();

                table.Add("id", reader["id"].ToString());

                table.Add("num", reader["num"].ToString());

                table.Add("person_id", reader["person_id"].ToString());

                table.Add("user_id", reader["user_id"].ToString());

                table.Add("opened", reader["opened"].ToString());

                table.Add("notee", reader["notee"].ToString());

                table.Add("datee", reader["datee"].ToString());

                table.Add("billq", getAllBillsQ(reader["id"].ToString()));

                table.Add("note2", reader["note2"].ToString());

                list.Add(table);
            }

            reader.Close();

            con.Close();

            return list;
        }

        public static ArrayList getAllBillsQ(string bill_id)
        {
            ArrayList list = new ArrayList();

            OleDbConnection con = createConnection();

            String selectSQL = "SELECT * FROM billq where bill_id=" + bill_id + " order by id";

            OleDbCommand command = new OleDbCommand(selectSQL, con);

            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Hashtable table = new Hashtable();

                table.Add("id", reader["id"].ToString());

                table.Add("bill_id", reader["bill_id"].ToString());

                table.Add("req_id", reader["req_id"].ToString());

                table.Add("q", reader["q"].ToString());

                table.Add("cost", reader["cost"].ToString());

                list.Add(table);
            }

            reader.Close();

            con.Close();

            return list;
        }

        public static ArrayList getBillsQ(string bill_id, string req_id)
        {
            ArrayList list = new ArrayList();

            OleDbConnection con = createConnection();

            String selectSQL = "SELECT * FROM billq where bill_id=" + bill_id + " and req_id=" + req_id + " order by id";

            OleDbCommand command = new OleDbCommand(selectSQL, con);

            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Hashtable table = new Hashtable();

                table.Add("id", reader["id"].ToString());

                table.Add("bill_id", reader["bill_id"].ToString());

                table.Add("req_id", reader["req_id"].ToString());

                table.Add("q", reader["q"].ToString());

                table.Add("cost", reader["cost"].ToString());

                list.Add(table);
            }

            reader.Close();

            con.Close();

            return list;
        }

        public static ArrayList getAllBillsQ1(string bill_id)
        {
            ArrayList list = new ArrayList();

            OleDbConnection con = createConnection();

            String selectSQL = "SELECT * FROM billq1 where bill_id=" + bill_id + " order by id";

            OleDbCommand command = new OleDbCommand(selectSQL, con);

            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Hashtable table = new Hashtable();

                table.Add("id", reader["id"].ToString());

                table.Add("bill_id", reader["bill_id"].ToString());

                table.Add("req_id", reader["req_id"].ToString());

                table.Add("q", reader["q"].ToString());

                table.Add("cost", reader["cost"].ToString());

                list.Add(table);
            }

            reader.Close();

            con.Close();

            return list;
        }

        public static Hashtable getM(string m_id)
        {
            Hashtable table = new Hashtable();

            OleDbConnection con = createConnection();

            String selectSQL = "SELECT * FROM m where id=" + m_id;

            OleDbCommand command = new OleDbCommand(selectSQL, con);

            OleDbDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                table.Add("id", reader["id"].ToString());

                table.Add("name", reader["name"].ToString());

                table.Add("part_id", reader["part_id"].ToString());

                table.Add("typeme", reader["typeme"].ToString());

                table.Add("qcm", getAllQCMForM(reader["id"].ToString()));

            }

            reader.Close();

            con.Close();

            return table;
        }

        public static Hashtable getM_back(string bill_id, string m_id)
        {
            Hashtable table = new Hashtable();

            OleDbConnection con = createConnection();

            String selectSQL = "SELECT * FROM m_back where id=" + m_id + " and bill_id=" + bill_id;

            OleDbCommand command = new OleDbCommand(selectSQL, con);

            OleDbDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                table.Add("id", reader["id"].ToString());

                table.Add("name", reader["name"].ToString());

                table.Add("part_id", reader["part_id"].ToString());

                table.Add("typeme", reader["typeme"].ToString());

                table.Add("qcm", getAllQCMForM_back(bill_id, reader["id"].ToString()));

            }

            reader.Close();

            con.Close();

            return table;
        }

        public static void updateM(string m_id, string name, string typeme)
        {
            OleDbConnection con = createConnection();

            String insertSQL = "update m set name='" + name + "' , typeme='" + typeme + "' where id =" + m_id;

            OleDbCommand command = new OleDbCommand(insertSQL, con);

            command.ExecuteNonQuery();

            con.Close();
        }

        public static void updateMPart(string m_id, string part_id)
        {
            OleDbConnection con = createConnection();

            String insertSQL = "update m set part_id=" + part_id + " where id =" + m_id;

            OleDbCommand command = new OleDbCommand(insertSQL, con);

            command.ExecuteNonQuery();

            con.Close();
        }

        public static void updateBillOpen(string bill_id, string opened)
        {
            OleDbConnection con = createConnection();

            String insertSQL = "update bill set opened='" + opened + "' where id =" + bill_id;

            OleDbCommand command = new OleDbCommand(insertSQL, con);

            command.ExecuteNonQuery();

            con.Close();
        }

        public static void updatePart(string part_id, string name)
        {
            OleDbConnection con = createConnection();

            String insertSQL = "update parts set name='" + name + "' where id =" + part_id;

            OleDbCommand command = new OleDbCommand(insertSQL, con);

            command.ExecuteNonQuery();

            con.Close();
        }

        public static void updatePart1(string part_id, string name)
        {
            OleDbConnection con = createConnection();

            String insertSQL = "update parts1 set name='" + name + "' where id =" + part_id;

            OleDbCommand command = new OleDbCommand(insertSQL, con);

            command.ExecuteNonQuery();

            con.Close();
        }

        public static void updateQCM(string qua, string cost, string qcm_id, string points)
        {
            OleDbConnection con = createConnection();

            String insertSQL = "update qcm set qua=" + qua + ",cost=" + cost + ",points=" + points + " where id =" + qcm_id;

            OleDbCommand command = new OleDbCommand(insertSQL, con);

            command.ExecuteNonQuery();

            con.Close();
        }

        public static void deleteAllZeroOfQCM()
        {
            OleDbConnection con = createConnection();

            string del = "delete from qcm where qua=0 and cost=0";

            OleDbCommand command = new OleDbCommand(del, con);

            command.ExecuteNonQuery();

            con.Close();

        }

        public static ArrayList getAllQCMForM(string m_id)
        {
            ArrayList list = new ArrayList();

            OleDbConnection con = createConnection();

            String selectSQL = "SELECT * FROM qcm where m_id=" + m_id + " order by id";

            OleDbCommand command = new OleDbCommand(selectSQL, con);

            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Hashtable table = new Hashtable();

                table.Add("id", reader["id"].ToString());

                table.Add("m_id", reader["m_id"].ToString());

                table.Add("qua", reader["qua"].ToString());

                table.Add("cost", reader["cost"].ToString());

                table.Add("points", reader["points"].ToString());

                list.Add(table);
            }

            reader.Close();

            con.Close();

            return list;
        }

        public static ArrayList getAllQCMForM_back(string bill_id, string m_id)
        {
            ArrayList list = new ArrayList();

            OleDbConnection con = createConnection();

            String selectSQL = "SELECT * FROM qcm_back where m_id=" + m_id + " and bill_id=" + bill_id + " order by id";

            OleDbCommand command = new OleDbCommand(selectSQL, con);

            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Hashtable table = new Hashtable();

                table.Add("id", reader["id"].ToString());

                table.Add("m_id", reader["m_id"].ToString());

                table.Add("qua", reader["qua"].ToString());

                table.Add("cost", reader["cost"].ToString());

                table.Add("points", reader["points"].ToString());

                list.Add(table);
            }

            reader.Close();

            con.Close();

            return list;
        }

        public static Hashtable getFatherOfPart(string part_id)
        {
            Hashtable table = new Hashtable();

            OleDbConnection con = createConnection();

            String selectSQL = "SELECT * FROM parts where id=" + part_id;

            OleDbCommand command = new OleDbCommand(selectSQL, con);

            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                table.Add("id", reader["id"].ToString());

                table.Add("num", reader["num"]);

                table.Add("name", reader["name"]);
            }

            reader.Close();

            con.Close();

            return table;
        }

        public static Hashtable getFatherOfPart1(string part_id)
        {
            Hashtable table = new Hashtable();

            OleDbConnection con = createConnection();

            String selectSQL = "SELECT * FROM parts1 where id=" + part_id;

            OleDbCommand command = new OleDbCommand(selectSQL, con);

            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                table.Add("id", reader["id"].ToString());

                table.Add("num", reader["num"]);

                table.Add("name", reader["name"]);
            }

            reader.Close();

            con.Close();

            return table;
        }

        public static void deletePart(string part_id)
        {
            OleDbConnection con = createConnection();

            string del = "delete from parts where id=" + part_id;

            OleDbCommand command = new OleDbCommand(del, con);

            command.ExecuteNonQuery();

            con.Close();

        }

        public static void deletePart1(string part_id)
        {
            OleDbConnection con = createConnection();

            string del = "delete from parts1 where id=" + part_id;

            OleDbCommand command = new OleDbCommand(del, con);

            command.ExecuteNonQuery();

            con.Close();

        }

        public static void deleteAllMFromPart(string part_id)
        {
            OleDbConnection con = createConnection();

            string del = "delete from m where part_id=" + part_id;

            OleDbCommand command = new OleDbCommand(del, con);

            command.ExecuteNonQuery();

            con.Close();

        }

        public static void deleteAllReqFromPart(string part_id)
        {
            OleDbConnection con = createConnection();

            string del = "delete from req where part_id=" + part_id;

            OleDbCommand command = new OleDbCommand(del, con);

            command.ExecuteNonQuery();

            con.Close();

        }

        public static void deleteM(string m_id)
        {
            OleDbConnection con = createConnection();

            string del = "delete from m where id=" + m_id;

            OleDbCommand command = new OleDbCommand(del, con);

            command.ExecuteNonQuery();

            con.Close();

        }

        public static void deleteQCM(string qcm_id)
        {
            OleDbConnection con = createConnection();

            string del = "delete from qcm where id=" + qcm_id;

            OleDbCommand command = new OleDbCommand(del, con);

            command.ExecuteNonQuery();

            con.Close();

        }

        public static string addUser(string name, string pass, string typeme)
        {
            OleDbConnection con = createConnection();

            String insertSQL = "insert into users (name,pass,typeme) values ('" + name + "','" + pass + "','" + typeme + "')";

            OleDbCommand command = new OleDbCommand(insertSQL, con);

            command.ExecuteNonQuery();

            con.Close();

            return getLastRowOFUsers();
        }

        public static string addPerson(string name)
        {
            OleDbConnection con = createConnection();

            String insertSQL = "insert into people (name) values ('" + name + "')";

            OleDbCommand command = new OleDbCommand(insertSQL, con);

            command.ExecuteNonQuery();

            con.Close();

            return getLastRowOFUsers();
        }

        public static string getLastRowOFUsers()
        {
            string lolo = "";

            OleDbConnection con = createConnection();

            String selectSQL = "SELECT max(id) as lolo FROM users";

            OleDbCommand command = new OleDbCommand(selectSQL, con);

            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                lolo = reader["lolo"].ToString();
            }

            reader.Close();

            con.Close();

            return lolo;

        }

        public static Hashtable getFatoraNumber()
        {
            Hashtable ss = new Hashtable();

            ss.Add("num", "1");

            ss.Add("datee", getMyDate());

            OleDbConnection con = createConnection();

            String selectSQL = "SELECT * FROM tbnum order by id";

            OleDbCommand command = new OleDbCommand(selectSQL, con);

            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string uu1 = ss["datee"].ToString().Substring(0, ss["datee"].ToString().IndexOf(" "));

                string uu2 = reader["datee"].ToString();

                if (uu1.Equals(uu2))
                {
                    int ii = int.Parse(reader["num"].ToString());
                    ss["num"] = (++ii).ToString();
                }
            }

            reader.Close();

            con.Close();

            return ss;

        }

        public static string getMyDate()
        {

            DateTimeFormatInfo myDTFI = new CultureInfo("en-US", true).DateTimeFormat;

            DateTime myDT = DateTime.Now;

            return myDT.ToString("dd/MM/yyyy H:mm", myDTFI);

        }

        public static string getMyDateWithSeconds()
        {

            DateTimeFormatInfo myDTFI = new CultureInfo("en-US", true).DateTimeFormat;

            DateTime myDT = DateTime.Now;

            return myDT.ToString("dd/MM/yyyy H:mm:s", myDTFI);

        }

        public static DateTime getMyDate(string date)
        {

            DateTimeFormatInfo myDTFI = new CultureInfo("en-US", true).DateTimeFormat;

            return DateTime.ParseExact(date, "dd/MM/yyyy H:mm", myDTFI);


        }

        public static ArrayList getAllUsers()
        {

            ArrayList list = new ArrayList();

            OleDbConnection con = createConnection();

            String selectSQL = "SELECT * FROM users order by id";

            OleDbCommand command = new OleDbCommand(selectSQL, con);

            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Hashtable table = new Hashtable();

                table.Add("id", reader["id"].ToString());

                table.Add("name", reader["name"].ToString());

                table.Add("pass", reader["pass"].ToString());

                table.Add("typeme", reader["typeme"].ToString());

                list.Add(table);
            }

            reader.Close();

            con.Close();

            return list;
        }

        public static ArrayList getAllPeople()
        {

            ArrayList list = new ArrayList();

            OleDbConnection con = createConnection();

            String selectSQL = "SELECT * FROM people order by id";

            OleDbCommand command = new OleDbCommand(selectSQL, con);

            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Hashtable table = new Hashtable();

                table.Add("id", reader["id"].ToString());

                table.Add("name", reader["name"].ToString());

                list.Add(table);
            }

            reader.Close();

            con.Close();

            return list;
        }

        public static Hashtable getPeople(string id)
        {

            Hashtable table = new Hashtable();

            OleDbConnection con = createConnection();

            String selectSQL = "SELECT * FROM people where id=" + id;

            OleDbCommand command = new OleDbCommand(selectSQL, con);

            OleDbDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                table.Add("id", reader["id"].ToString());

                table.Add("name", reader["name"].ToString());
            }

            reader.Close();

            con.Close();

            return table;
        }

        public static Hashtable getUser(string user_id)
        {
            Hashtable table = new Hashtable();

            OleDbConnection con = createConnection();

            String selectSQL = "SELECT * FROM users where id=" + user_id;

            OleDbCommand command = new OleDbCommand(selectSQL, con);

            OleDbDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                table.Add("id", reader["id"].ToString());

                table.Add("name", reader["name"].ToString());

                table.Add("pass", reader["pass"].ToString());

                table.Add("typeme", reader["typeme"].ToString());

            }

            reader.Close();

            con.Close();

            return table;
        }

        public static void updateUser(string user_id, string name, string pass, string typeme)
        {
            OleDbConnection con = createConnection();

            String insertSQL = "update users set name='" + name + "' , pass='" + pass + "' , typeme='" + typeme + "' where id =" + user_id;

            OleDbCommand command = new OleDbCommand(insertSQL, con);

            command.ExecuteNonQuery();

            con.Close();
        }

        public static void updatePerson(string user_id, string name)
        {
            OleDbConnection con = createConnection();

            String insertSQL = "update people set name='" + name + "' where id =" + user_id;

            OleDbCommand command = new OleDbCommand(insertSQL, con);

            command.ExecuteNonQuery();

            con.Close();
        }

        public static Hashtable checkUserNameAndPass(string name, string pass)
        {
            Hashtable table = new Hashtable();

            OleDbConnection con = createConnection();

            String selectSQL = "SELECT * FROM users where name='" + name + "' and pass='" + pass + "'";

            OleDbCommand command = new OleDbCommand(selectSQL, con);

            OleDbDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                table.Add("id", reader["id"].ToString());

                table.Add("name", reader["name"].ToString());

                table.Add("pass", reader["pass"].ToString());

                table.Add("typeme", reader["typeme"].ToString());
            }

            reader.Close();

            con.Close();

            return table;
        }

        public static string addReq(string part_id, string req_name, string req_hadar, string num1, string num2, string num3)
        {
            OleDbConnection con = createConnection();

            String insertSQL = "insert into req (part_id,name,hader,num1,num2,num3) values (" + part_id + ",'" + req_name + "'," + req_hadar + "," + num1 + "," + num2 + "," + num3 + ")";

            OleDbCommand command = new OleDbCommand(insertSQL, con);

            command.ExecuteNonQuery();

            con.Close();

            return getLastRowOFReq();

        }

        public static void updateReq(string id, string req_name, string req_hadar, string num1, string num2, string num3)
        {
            OleDbConnection con = createConnection();

            String insertSQL = "update req set name='" + req_name + "',hader=" + req_hadar + ",num1=" + num1 + ",num2=" + num2 + ",num3=" + num3 + " where id =" + id;

            OleDbCommand command = new OleDbCommand(insertSQL, con);

            command.ExecuteNonQuery();

            con.Close();
        }

        public static void addReq_back(string bill_id, string part_id, string id, string req_name, string req_hadar, string num1, string num2, string num3)
        {
            OleDbConnection con = createConnection();

            String insertSQL = "insert into req_back (bill_id,part_id,id,name,hader,num1,num2,num3) values (" + bill_id + "," + part_id + "," + id + ",'" + req_name + "'," + req_hadar + "," + num1 + "," + num2 + "," + num3 + ")";

            OleDbCommand command = new OleDbCommand(insertSQL, con);

            command.ExecuteNonQuery();

            con.Close();
        }

        public static string getLastRowOFReq()
        {
            string lolo = "";

            OleDbConnection con = createConnection();

            String selectSQL = "SELECT max(id) as lolo FROM req";

            OleDbCommand command = new OleDbCommand(selectSQL, con);

            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                lolo = reader["lolo"].ToString();
            }

            reader.Close();

            con.Close();

            return lolo;

        }

        public static string addQcreq(string req_id, string m_id, string qua)
        {
            OleDbConnection con = createConnection();

            String insertSQL = "insert into qcreq (req_id,m_id,qua) values (" + req_id + "," + m_id + "," + qua + ")";

            OleDbCommand command = new OleDbCommand(insertSQL, con);

            command.ExecuteNonQuery();

            con.Close();

            return getLastRowOFM();
        }

        public static void updateQcreq(string id, string req_id, string m_id, string qua)
        {
            OleDbConnection con = createConnection();

            String insertSQL = "update qcreq set req_id=" + req_id + " , m_id=" + m_id + ",qua=" + qua + " where id =" + id;

            OleDbCommand command = new OleDbCommand(insertSQL, con);

            command.ExecuteNonQuery();

            con.Close();
        }

        public static void addQcreq_back(string bill_id, string id, string req_id, string m_id, string qua)
        {
            OleDbConnection con = createConnection();

            String insertSQL = "insert into qcreq_back (bill_id,id,req_id,m_id,qua) values (" + bill_id + "," + id + "," + req_id + "," + m_id + "," + qua + ")";

            OleDbCommand command = new OleDbCommand(insertSQL, con);

            command.ExecuteNonQuery();

            con.Close();

        }

        public static Hashtable getReq_back(string bill_id, string req_id)
        {
            Hashtable table = new Hashtable();

            OleDbConnection con = createConnection();

            String selectSQL = "SELECT * FROM req_back where id=" + req_id + " and bill_id=" + bill_id;

            OleDbCommand command = new OleDbCommand(selectSQL, con);

            OleDbDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {


                table.Add("id", reader["id"].ToString());

                table.Add("name", reader["name"].ToString());

                table.Add("hader", reader["hader"].ToString());

                table.Add("num1", reader["num1"].ToString());

                table.Add("num2", reader["num2"].ToString());

                table.Add("num3", reader["num3"].ToString());

                table.Add("part_id", reader["part_id"].ToString());

                table.Add("qcreq", getAllQcreq_back(bill_id, reader["id"].ToString()));

            }

            reader.Close();

            con.Close();

            return table;
        }

        public static ArrayList getAllReq(string part_id)
        {
            ArrayList list = new ArrayList();

            OleDbConnection con = createConnection();

            String selectSQL = "SELECT * FROM req where part_id=" + part_id + " order by name";

            OleDbCommand command = new OleDbCommand(selectSQL, con);

            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Hashtable table = new Hashtable();

                table.Add("id", reader["id"].ToString());

                table.Add("name", reader["name"].ToString());

                table.Add("hader", reader["hader"].ToString());

                table.Add("num1", reader["num1"].ToString());

                table.Add("num2", reader["num2"].ToString());

                table.Add("num3", reader["num3"].ToString());

                table.Add("part_id", reader["part_id"].ToString());

                table.Add("qcreq", getAllQcreq(reader["id"].ToString()));

                list.Add(table);
            }

            reader.Close();

            con.Close();

            return list;
        }

        public static ArrayList getAllReq()
        {
            ArrayList list = new ArrayList();

            OleDbConnection con = createConnection();

            String selectSQL = "SELECT * FROM req order by name";

            OleDbCommand command = new OleDbCommand(selectSQL, con);

            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                lolo ss = new lolo();

                Hashtable table = new Hashtable();

                table.Add("id", reader["id"].ToString());

                table.Add("name", reader["name"].ToString());

                table.Add("hader", reader["hader"].ToString());

                table.Add("num1", reader["num1"].ToString());

                table.Add("num2", reader["num2"].ToString());

                table.Add("num3", reader["num3"].ToString());

                table.Add("part_id", reader["part_id"].ToString());

                table.Add("qcreq", getAllQcreq(reader["id"].ToString()));

                ss.tabe = table;

                list.Add(ss);
            }

            reader.Close();

            con.Close();

            return list;
        }

        public static Hashtable getReq(string req_id)
        {
            Hashtable table = new Hashtable();

            OleDbConnection con = createConnection();

            String selectSQL = "SELECT * FROM req where id=" + req_id + " order by name";

            OleDbCommand command = new OleDbCommand(selectSQL, con);

            OleDbDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {

                table.Add("id", reader["id"].ToString());

                table.Add("name", reader["name"].ToString());

                table.Add("hader", reader["hader"].ToString());

                table.Add("num1", reader["num1"].ToString());

                table.Add("num2", reader["num2"].ToString());

                table.Add("num3", reader["num3"].ToString());

                table.Add("part_id", reader["part_id"].ToString());

                table.Add("qcreq", getAllQcreq(reader["id"].ToString()));

            }

            reader.Close();

            con.Close();

            return table;
        }

        public static void deleteReq(string req_id)
        {
            OleDbConnection con = createConnection();

            string del = "delete from req where id=" + req_id;

            OleDbCommand command = new OleDbCommand(del, con);

            command.ExecuteNonQuery();

            con.Close();

        }

        public static void deleteBill1(string bill_id)
        {
            OleDbConnection con = createConnection();

            string del = "delete from bill1 where id=" + bill_id;

            OleDbCommand command = new OleDbCommand(del, con);

            command.ExecuteNonQuery();

            con.Close();

        }

        public static void deleteAllQcreqFromReqID(string req_id)
        {
            OleDbConnection con = createConnection();

            string del = "delete from qcreq where req_id=" + req_id;

            OleDbCommand command = new OleDbCommand(del, con);

            command.ExecuteNonQuery();

            con.Close();

        }

        public static void deleteQcreq(string Qcreq_id)
        {
            OleDbConnection con = createConnection();

            string del = "delete from qcreq where id=" + Qcreq_id;

            OleDbCommand command = new OleDbCommand(del, con);

            command.ExecuteNonQuery();

            con.Close();

        }

        public static void deleteAllBillQByBillID1(string bill_id)
        {
            OleDbConnection con = createConnection();

            string del = "delete from billq1 where bill_id=" + bill_id;

            OleDbCommand command = new OleDbCommand(del, con);

            command.ExecuteNonQuery();

            con.Close();

        }

        public static ArrayList getAllQcreq(string req_id)
        {
            ArrayList list = new ArrayList();

            OleDbConnection con = createConnection();

            String selectSQL = "SELECT * FROM qcreq where req_id=" + req_id + " order by id";

            OleDbCommand command = new OleDbCommand(selectSQL, con);

            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Hashtable table = new Hashtable();

                table.Add("id", reader["id"].ToString());

                table.Add("req_id", reader["req_id"].ToString());

                table.Add("m_id", reader["m_id"].ToString());

                table.Add("qua", reader["qua"].ToString());

                list.Add(table);
            }

            reader.Close();

            con.Close();

            return list;
        }

        public static ArrayList getAllQcreq_back(string bill_id, string req_id)
        {
            ArrayList list = new ArrayList();

            OleDbConnection con = createConnection();

            String selectSQL = "SELECT * FROM qcreq_back where req_id=" + req_id + " and bill_id=" + bill_id + " order by id";

            OleDbCommand command = new OleDbCommand(selectSQL, con);

            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Hashtable table = new Hashtable();

                table.Add("id", reader["id"].ToString());

                table.Add("req_id", reader["req_id"].ToString());

                table.Add("m_id", reader["m_id"].ToString());

                table.Add("qua", reader["qua"].ToString());

                //table.Add("m", getM_back(reader["m_id"].ToString()));

                list.Add(table);
            }

            reader.Close();

            con.Close();

            return list;
        }

    }

    public class lolo
    {
        public double cost = -1;
        public int q = -1;
        public int end = -1;
        public Hashtable tabe = new Hashtable();

        public override string ToString()
        {
            return tabe["name"].ToString();
        }

    }

    public class koko : EventArgs
    {
        public string bill_id = "";

        public string note2 = "";

        public string notee = "";

    }
}