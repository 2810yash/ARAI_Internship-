using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace AdminTemplate3._1._0
{
    public partial class Welcome : System.Web.UI.Page
    {
        string Main_con = ConfigurationManager.ConnectionStrings["strconn"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                arai_Engineer_list();
                workPermit_list();
            }
        }

        protected void addWorkPermit_Click(object sender, EventArgs e)
        {
            // Create a new dropdown list control
            DropDownList ddlNewDropDown = new DropDownList();

            // Set properties of the dropdown list
            ddlNewDropDown.ID = "DynamicDropDownList"; // Set a unique ID for the dropdown list
            ddlNewDropDown.Items.Add(new ListItem("-- Select --", "")); // Add default item
            ddlNewDropDown.Items.Add(new ListItem("Option 1", "1")); // Add example items

            // Add the dropdown list to the placeholder
            DropDownPlaceHolder.Controls.Add(ddlNewDropDown);
        }

        protected void workPermit_list()
        {

            workPermit.Items.Insert(0, new ListItem("-- Select Work Permit --", "0"));
        }
        protected void arai_Engineer_list()
        {
            SqlConnection sqlcon = new SqlConnection(Main_con);
            sqlcon.Open();
            SqlCommand sql_command = new SqlCommand("SELECT * FROM [dbo].[engineer_name_tbl]", sqlcon);
            sql_command.CommandType = CommandType.Text;
            araiEng.DataSource = sql_command.ExecuteReader();
            araiEng.DataTextField = "EngineerName";
            //araiEng.DataValueField = "DeptID";
            araiEng.DataBind();
            araiEng.Items.Insert(0, new ListItem("-- Select Engineer Name --", "0"));
        }

        protected void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            string labelText = checkBox.Text;

            // Get the list container
            ListBox listContainer = (ListBox)FindControl("listContainer");

            if (listContainer != null)
            {
                if (checkBox.Checked)
                {
                    // Add the checkbox text to the list container
                    listContainer.Items.Add(new ListItem(labelText));
                }
                else
                {
                    // Remove the checkbox text from the list container if it exists
                    ListItem itemToRemove = listContainer.Items.FindByText(labelText);
                    if (itemToRemove != null)
                    {
                        listContainer.Items.Remove(itemToRemove);
                    }
                }
            }
        }

        protected void special_license_CheckedChanged(object sender, EventArgs e){}

        protected void confirm_Click(object sender, EventArgs e)
        {
            // Parse the number of workers entered in the TextBox
            int numberOfWorkers;
            if (int.TryParse(TextBox7.Text, out numberOfWorkers))
            {
                // Clear any previous content in the workers div
                workers.Controls.Clear();

                // Create a new table
                Table table = new Table();
                table.CssClass = "table table-bordered"; // Optionally, you can set CSS class for the table

                // Create the first row with headers
                TableRow tableFirstRow = new TableRow();
                string[] headerText = { "Sr. No.", "Name of Workers", "AGE", "Mask", "Safety Shoes/ Gum Boots", "Jackets/ Aprons", "Gloves", "Ear plug/ muffs", "Belt/ Harness", "Remarks" };
                for (int i = 0; i < headerText.Length; i++)
                {
                    TableCell cell = new TableCell();
                    cell.Text = headerText[i];
                    tableFirstRow.Cells.Add(cell);
                }
                table.Rows.Add(tableFirstRow);

                // Create table rows and cells based on the number of workers
                for (int i = 0; i < numberOfWorkers; i++)
                {
                    TableRow row = new TableRow();

                    // Add Sr. No. column with sequential numbers
                    TableCell srNoCell = new TableCell();
                    srNoCell.Text = (i + 1).ToString();
                    row.Cells.Add(srNoCell);

                    // Add TextBox for Name of Workers column
                    TableCell nameCell = new TableCell();
                    nameCell.Controls.Add(new TextBox { ID = "txtName_" + i }); // Assign a unique ID to each TextBox
                    row.Cells.Add(nameCell);

                    // Add a TextBox for Age column
                    TableCell ageCell = new TableCell();
                    TextBox ageTextBox = new TextBox { ID = "txtAge_" + i };
                    ageCell.Controls.Add(ageTextBox);
                    row.Cells.Add(ageCell);

                    // Add RegularExpressionValidator for Age column
                    RegularExpressionValidator ageValidator = new RegularExpressionValidator();
                    ageValidator.ControlToValidate = ageTextBox.ID;
                    ageValidator.ValidationExpression = @"\d+"; // Regular expression to match digits only
                    ageValidator.ErrorMessage = "Please enter a numeric value for Age.";
                    ageValidator.CssClass = "text-danger"; // Optional: Add CSS class for error messages
                    ageCell.Controls.Add(ageValidator);

                    // Add CheckBox for Mask column
                    TableCell maskCell = new TableCell();
                    maskCell.Controls.Add(new CheckBox { ID = "chkMask_" + i, Checked = true }); // Assign a unique ID to each CheckBox
                    row.Cells.Add(maskCell);

                    // Add CheckBox for Safety Shoes/Gum Boots column
                    TableCell safetyShoesCell = new TableCell();
                    safetyShoesCell.Controls.Add(new CheckBox { ID = "chkSafetyShoes_" + i, Checked = true }); // Assign a unique ID to each CheckBox
                    row.Cells.Add(safetyShoesCell);

                    // Add CheckBox for Jackets/Aprons column
                    TableCell jacketsCell = new TableCell();
                    jacketsCell.Controls.Add(new CheckBox { ID = "chkJackets_" + i, Checked = true }); // Assign a unique ID to each CheckBox
                    row.Cells.Add(jacketsCell);

                    // Add CheckBox for Gloves column
                    TableCell glovesCell = new TableCell();
                    glovesCell.Controls.Add(new CheckBox { ID = "chkGloves_" + i, Checked = true }); // Assign a unique ID to each CheckBox
                    row.Cells.Add(glovesCell);

                    // Add CheckBox for Ear plug/muffs column
                    TableCell earPlugsCell = new TableCell();
                    earPlugsCell.Controls.Add(new CheckBox { ID = "chkEarPlugs_" + i, Checked = true }); // Assign a unique ID to each CheckBox
                    row.Cells.Add(earPlugsCell);

                    // Add CheckBox for Belt/Harness column
                    TableCell beltCell = new TableCell();
                    beltCell.Controls.Add(new CheckBox { ID = "chkBelt_" + i, Checked = true }); // Assign a unique ID to each CheckBox
                    row.Cells.Add(beltCell);

                    // Add TextBox for Remarks column
                    TableCell remarksCell = new TableCell();
                    remarksCell.Controls.Add(new TextBox { ID = "txtRemarks_" + i }); // Assign a unique ID to each TextBox
                    row.Cells.Add(remarksCell);

                    table.Rows.Add(row);
                }

                // Add the table to the workers div
                workers.Controls.Add(table);
            }
            else
            {
                // Display a message or take appropriate action if the input is invalid
                // For example: Response.Write("Invalid input for the number of workers.");
            }
        }
    }
}