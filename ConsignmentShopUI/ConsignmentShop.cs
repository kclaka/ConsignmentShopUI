﻿using consignmentShopLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsignmentShopUI
{
    public partial class ConsignmentShop : Form
    {
        public ConsignmentShop()
        {
            InitializeComponent();
            setupData();

            ItemBinding.DataSource = store.Items.Where(x => x.sold == false).ToList();
            itemListBox.DataSource = ItemBinding;

            itemListBox.DisplayMember = "Display";
            itemListBox.ValueMember = "Display";

            cartBinding.DataSource = shoppingcartData;
            shoppingCartListBox.DataSource = cartBinding;
            vendorbinding.DataSource = store.Vendors;
            vendorListBox.DataSource = vendorbinding;

            shoppingCartListBox.DisplayMember = "Display";
            shoppingCartListBox.ValueMember = "Display";
            vendorListBox.DisplayMember = "Display";
            vendorListBox.ValueMember = "Display";

        }

        private Store store = new Store();
        private List<Item> shoppingcartData = new List<Item>();
        BindingSource ItemBinding = new BindingSource();
        BindingSource cartBinding = new BindingSource();
        BindingSource vendorbinding = new BindingSource();


        private void setupData()
        {
            store.Vendors.Add(new Vendor { firstName = "Kenny", lastName = "Ashton", commission = .5 });
            store.Vendors.Add(new Vendor { firstName = "John", lastName = "Markus", commission = .3 });
            store.Vendors.Add(new Vendor { firstName = "Chloe", lastName = "Waylor", commission = 0.2 });


            store.Items.Add(new Item
            {
                title = "Xbox X",
                description = "New Xbox form MSFT",
                price = 400.00M,
                PaymentDistributed = false,
                sold = false,
                Owner = store.Vendors[0]
            });

            store.Items.Add(new Item
            {
                title = "Xbox Controller",
                description = "Xbox Controller for XBOX",
                price = 150.00M,
                PaymentDistributed = false,
                sold = false,
                Owner = store.Vendors[1]
            });

            store.Items.Add(new Item
            {
                title = "Head Phones",
                description = "A head Phone for Gamers",
                price = 190.00M,
                PaymentDistributed = false,
                sold = false,
                Owner = store.Vendors[2]
            });

            store.Items.Add(new Item
            {
                title = "Wifi Router",
                description = "High Range Wifi",
                price = 120.00M,
                PaymentDistributed = false,
                sold = false,
                Owner = store.Vendors[2]
            });


            store.Name = "Game Pro Shopping";

        }

        private void ConsignmentShop_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void shoppingCartListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void addtoCart_Click(object sender, EventArgs e)
        {
            Item selectedItem = (Item)itemListBox.SelectedItem;
            shoppingcartData.Add(selectedItem);

            cartBinding.ResetBindings(false);


        }

        private void purchaseButton_Click(object sender, EventArgs e)
        {
            foreach (Item item in shoppingcartData)
            {
                item.sold = true;
                item.Owner.PaymentDue += (decimal)item.Owner.commission + item.price;
            }

            ItemBinding.DataSource = store.Items.Where(x => x.sold == false).ToList();
            shoppingcartData.Clear();
            cartBinding.ResetBindings(false);
            vendorbinding.ResetBindings(false);
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
