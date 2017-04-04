using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SKF.Admin
{
    public partial class Add_Fees : System.Web.UI.Page
    {
        Connect cls = new Connect();
        string sqlstmt = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindSchool();
                BindBillType();
                BindStudentsAlone();
                BindStaffNameAlone();
                var unique_id = Request.QueryString["id"];
                if (unique_id != null)
                {
                    GetData();
                }
            }
        }

        public void BindSchool()
        {
            sqlstmt = "";
            sqlstmt = "Select * from school_master";
            DataSet ds = cls.Select(sqlstmt);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DropSchooName.DataSource = ds.Tables[0];
                DropSchooName.DataTextField = "school_name";
                DropSchooName.DataValueField = "school_id";
                DropSchooName.DataBind();
            }
            else
            {
                DropSchooName.DataSource = System.DBNull.Value.ToString();
                DropSchooName.DataBind();
            }
            DropSchooName.Items.Insert(0, "--Select--");
        }
        public void BindStudents()
        {
            sqlstmt = "";
            sqlstmt = "Select * from student_master where stu_school_id ="+ DropSchooName.SelectedValue;
            DataSet ds = cls.Select(sqlstmt);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DropStuName.DataSource = ds.Tables[0];
                DropStuName.DataTextField = "stu_name";
                DropStuName.DataValueField = "stu_id";
                DropStuName.DataBind();
            }
            else
            {
                DropStuName.DataSource = System.DBNull.Value.ToString();
                DropStuName.DataBind();
            }
            DropStuName.Items.Insert(0, "--Select--");
        }
        public void BindStudentsAlone()
        {
            sqlstmt = "";
            sqlstmt = "Select * from student_master";
            DataSet ds = cls.Select(sqlstmt);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DropStuName.DataSource = ds.Tables[0];
                DropStuName.DataTextField = "stu_name";
                DropStuName.DataValueField = "stu_id";
                DropStuName.DataBind();
            }
            else
            {
                DropStuName.DataSource = System.DBNull.Value.ToString();
                DropStuName.DataBind();
            }
            DropStuName.Items.Insert(0, "--Select--");
        }
        public void BindBillType()
        {
            sqlstmt = "";
            sqlstmt = "Select * from bill_type";
            DataSet ds = cls.Select(sqlstmt);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DropBillType.DataSource = ds.Tables[0];
                DropBillType.DataTextField = "bill_type_name";
                DropBillType.DataValueField = "bill_type_id";
                DropBillType.DataBind();
            }
            else
            {
                DropBillType.DataSource = System.DBNull.Value.ToString();
                DropBillType.DataBind();
            }
            DropBillType.Items.Insert(0, "--Select--");
        }
        public void BindStaffName()
        {
            sqlstmt = "";
            sqlstmt = "Select * from staff_master where school_id ="+ DropSchooName.SelectedValue;
            DataSet ds = cls.Select(sqlstmt);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DropStaffName.DataSource = ds.Tables[0];
                DropStaffName.DataTextField = "staff_name";
                DropStaffName.DataValueField = "staff_id";
                DropStaffName.DataBind();
            }
            else
            {
                DropStaffName.DataSource = System.DBNull.Value.ToString();
                DropStaffName.DataBind();
            }
            DropStaffName.Items.Insert(0, "--Select--");
        }
        public void BindStaffNameAlone()
        {
            sqlstmt = "";
            sqlstmt = "Select * from staff_master";
            DataSet ds = cls.Select(sqlstmt);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DropStaffName.DataSource = ds.Tables[0];
                DropStaffName.DataTextField = "staff_name";
                DropStaffName.DataValueField = "staff_id";
                DropStaffName.DataBind();
            }
            else
            {
                DropStaffName.DataSource = System.DBNull.Value.ToString();
                DropStaffName.DataBind();
            }
            DropStaffName.Items.Insert(0, "--Select--");
        }

        public void GetData()
        {
            var unique_id = Request.QueryString["id"];
            sqlstmt = "";
            sqlstmt = "SELECT * FROM bill_master INNER JOIN student_master ON bill_master.bill_stu_id = student_master.stu_id INNER JOIN school_master ON student_master.stu_school_id = school_master.school_id INNER JOIN staff_master ON bill_master.bill_receiver_id = staff_master.staff_id INNER JOIN bill_type ON bill_master.bill_type_id = bill_type.bill_type_id where bill_id = " + unique_id.ToString();
            DataSet ds = cls.Select(sqlstmt);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DropSchooName.SelectedValue = ds.Tables[0].Rows[0]["stu_school_id"].ToString();
                DropStuName.SelectedValue = ds.Tables[0].Rows[0]["bill_stu_id"].ToString();
                DropBillType.SelectedValue = ds.Tables[0].Rows[0]["bill_type_id"].ToString();
                txtBillReceiveAmount.Text = ds.Tables[0].Rows[0]["bill_amount_paid"].ToString();
                DropStaffName.SelectedValue = ds.Tables[0].Rows[0]["bill_receiver_id"].ToString();
            }
        }

        public void CrudOP()
        {
            var unique_id = Request.QueryString["id"];
            if (unique_id == null)
            {
                sqlstmt = "";
                sqlstmt = "Insert into bill_master (bill_stu_id,bill_type_id,bill_datetime,bill_amount_paid,bill_receiver_id,bill_paid) values ('"+ DropStuName.SelectedValue +"','"+ DropBillType.SelectedValue +"','"+ DateTime.Now.ToString() +"','"+ txtBillReceiveAmount.Text.Trim() +"','"+ DropStaffName.SelectedValue +"','Paid')";
                cls.Insert(sqlstmt);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Activity", "alert('Record Inserted..!')", true);
                Response.Redirect("Fees.aspx");
                //ShowMessageBox("Activities.aspx","Record Inserted..!");    
            }
            else
            {
                sqlstmt = "";
                sqlstmt = "Update bill_master set bill_datetime = '"+ DateTime.Now.ToString() + "',bill_amount_paid = '"+ txtBillReceiveAmount.Text.Trim() +"'  where bill_id =" + unique_id.ToString();
                cls.Update(sqlstmt);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Activity", "alert('Record Updated..!')", true);
                Response.Redirect("Fees.aspx");
                //ShowMessageBox("Activities.aspx", "Record Updated..!");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            CrudOP();
        }

        protected void DropSchooName_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindStudents();
            BindStaffName();
        }
    }
}