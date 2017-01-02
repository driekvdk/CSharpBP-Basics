using Acme.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz
{
    /// <summary>
    /// Msnsges products carries in inventory
    /// </summary>
    public class Product
    {
        public const double InchesPerMeter = 39.37;
        public readonly decimal MinimumPrice;

        #region Constructors
        public Product()
        {
            Console.WriteLine("Product instance created");
            //this.productVendor = new Vendor();
            this.MinimumPrice = .96m;
            this.Category = "Tools";
        }

        public Product(int productId, string productName, string description) : this()
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.Description = description;
            if (ProductName.StartsWith("bulk_"))
            {
                this.MinimumPrice = 9.99m;
            }
            Console.WriteLine("Product instance has a name: " + ProductName);
        }
        #endregion

        #region Properties
        private DateTime? availabilityDate;

        public DateTime? AvailabilityDate
        {
            get { return availabilityDate; }
            set { availabilityDate = value; }
        }

        private string productName;
                
        public string ProductName
        {
            get
            {
                string formattedValue = productName?.Trim();
                return formattedValue;
            }
            set
            {
                if (value.Length < 3)
                {
                    ValidationMessage = "Productname is too short";
                }
                else if (value.Length < 20)
                {
                    ValidationMessage = "Productname is too long";
                }
                else
                {
                    productName = value;
                }
            }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private int productId;

        public int ProductId
        {
            get { return productId; }
            set { productId = value; }
        }
        private Vendor productVendor;

        public Vendor ProductVendor
        {
            get
            {
                if (productVendor == null)
                {
                    productVendor = new Vendor();
                }
                return productVendor;
            }
            set { productVendor = value; }
        }

        public string ValidationMessage { get; private set; }

        public string Category { get; set; }
        public int SequenceNumber { get; set; } = 1;

        public string ProductCode => this.Category + "-" + this.SequenceNumber;

        #endregion

        public string SayHello ()
        {
            //var Vendor = new Vendor();
            //Vendor.SendWelcomeEmail("Message from product");

            var emailService = new EmailService();
            var conformation = emailService.SendMessage("New product", this.ProductName, "sales@abc.com");

            var result = LoggingService.LogAction("Saying Hello");

            return "Hello " + ProductName + " (" + ProductId + "): " 
                + Description + 
                " Available on: " + this.AvailabilityDate?.ToShortDateString() ;
        }
    }
}
