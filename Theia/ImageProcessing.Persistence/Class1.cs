using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace ImageProcessing.Persistence
{
    public class Class1
    {
        public Class1()
        {
            //connect to MySQL
            SqlConnection BlobsDatabaseConn = new SqlConnection("Data Source = 127.0.0.1; Initial Catalog = image_testl; Integrated Security = SSPI");
            SqlCommand SaveBlobCommand = new SqlCommand();
            SaveBlobCommand.Connection = BlobsDatabaseConn;
            SaveBlobCommand.CommandType = CommandType.Text;
            SaveBlobCommand.CommandText = "INSERT INTO image_testl(IMAGE_ID, IMAGE_NAME, IMAGE_DESCRIPTION, IMAGE)" + "VALUES (1, 'First', 'Test Image', )";
        }
    }
}
