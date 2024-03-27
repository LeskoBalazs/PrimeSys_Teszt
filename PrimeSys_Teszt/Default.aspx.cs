using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrimeSys_Teszt
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        protected List<Product> GetProducts()
        {
            List<Product> products = Session["Products"] as List<Product>;
            if (products == null) //if there are no products, it creates a new list
            {
                products = new List<Product>();
            }
            return products;
        }

        protected void BindGrid() //shows the products in a table
        {
            List<Product> products = GetProducts();
            GridView1.DataSource = products;
            GridView1.DataBind();
        }

        protected void btnAddProduct_Click(object sender, EventArgs e)
        {
            List<Product> products = GetProducts();
            string productName = txtProductName.Text;
            int price = int.Parse(txtPrice.Text);

            //check if there is a product with the same name
            bool productExists = products.Any(p => p.Name.Equals(productName, StringComparison.OrdinalIgnoreCase));
            if (productExists)
            {
                // Display an error message indicating that a product with the same name already exists
                ScriptManager.RegisterStartupScript(this, GetType(), "ProductExistsAlert", "alert('Ezzel a névvel már szerepel termék a táblázatban!');", true);
            }
            else
            {
                Product newProduct = new Product
                {
                    ID = products.Count > 0 ? products.Max(p => p.ID) + 1 : 1, //setting the ID, if list is empty it is 1, if not, it adds 1 to the latest ID
                    Name = productName,
                    Price = price,
                    Made = DateTime.Now,
                    Expire = DateTime.Now.AddDays(30)
                };

                products.Add(newProduct);
                Session["Products"] = products;

                BindGrid();
            }

            
        }

        protected void RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex; //selects the row you click edit on
            BindGrid(); 
        }

        protected void RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            List<Product> products = GetProducts();
            int rowIndex = e.RowIndex; //selects the row you click delete on

            if (rowIndex >= 0 && rowIndex < GridView1.Rows.Count)
            {
                products.RemoveAt(rowIndex); //removes selected row
                Session["Products"] = products;
                BindGrid();
            }
        }
       //for some reason it doesn't work :(
        protected void RowUpdating(object sender, GridViewUpdateEventArgs e) 
        {
            List<Product> products = GetProducts();
            int rowIndex = e.RowIndex;

            if (rowIndex >= 0 && rowIndex < GridView1.Rows.Count)
            {
                GridViewRow row = GridView1.Rows[rowIndex];
                int productId = int.Parse(((Label)row.FindControl("lblID")).Text);

                TextBox txtName = (TextBox)row.FindControl("txtName");
                TextBox txtPrice = (TextBox)row.FindControl("txtPrice");


                Product productToUpdate = products.Find(p => p.ID == productId);
                if (productToUpdate != null)
                {
                    productToUpdate.Name = txtName.Text;
                    productToUpdate.Price = int.Parse(txtPrice.Text);
                }

                GridView1.EditIndex = -1;
                Session["Products"] = products;
                BindGrid();
            }
        }

        protected void RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //you can cancel your modifications on a product
            GridView1.EditIndex = -1; //no row was edited
            BindGrid();
        }
        
        
        //defining class and attributes
        public class Product
        {
            private int id;
            private string name;
            private int price;
            private DateTime made;
            private DateTime expire;

            //Public properites to get and set attributes
            public int ID
            {
                get { return id; }
                set { id = value; }
            }
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            public int Price
            {
                get { return price; }
                set { price = value; }
            }
            public DateTime Made
            {
                get { return made; }
                set { made = value; }
            }
            public DateTime Expire
            {
                get { return expire; }
                set { expire = value; }
            }
        }
    }
}