// Anita Martin
// amartin98@cnm.edu
// Title: DBDemo- In class assignment

// MainWindow.xaml.cs

using DBDemo;
using System;
using System.Collections.Generic;
using System.Windows;

namespace DBDemoInClass
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<InventoryItem> items = new List<InventoryItem>();
        InventoryItemsService service = new InventoryItemsService();
        public MainWindow()
        {
            InitializeComponent();
            RefreshView();
            lbItems.SelectedIndex = 0;
            ShowSelectedItems();
        }

        private void RefreshView()
        {
            items = service.GetAll();
            lbItems.ItemsSource = items;
            lbItems.Items.Refresh();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            ShowSelectedItems();
        }


        private void lbItems_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ShowSelectedItems();
        }


        private void ShowSelectedItems()
        {
            InventoryItem item = (InventoryItem)lbItems.SelectedItem;
            txbId.Text = item.Id.ToString();
            txbName.Text = item.Name;
            txbLocation.Text = item.Location.ToString();
            txbWeight.Text = item.Weight.ToString();
            txbCost.Text = item.Cost.ToString("c");
            txbRemarks.Text = item.Remarks;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            InventoryItem item = new InventoryItem();
            item.Name = txbName.Text;
            item.Location = int.Parse(txbLocation.Text);
            item.Weight = double.Parse(txbWeight.Text);
            item.Cost = Decimal.Parse(txbCost.Text, System.Globalization.NumberStyles.Currency);
            item.Remarks = txbRemarks.Text;
            service.AddItem(item);
            RefreshView();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            InventoryItem itemToDelete = (InventoryItem)lbItems.SelectedItem;
            service.DeleteItem(itemToDelete.Id);
            RefreshView();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            InventoryItem item = new InventoryItem();
            item.Id = int.Parse(txbId.Text);
            item.Name = txbName.Text;
            item.Location = int.Parse(txbLocation.Text);
            item.Weight = double.Parse(txbWeight.Text);
            item.Cost = Decimal.Parse(txbCost.Text, System.Globalization.NumberStyles.Currency);
            item.Remarks = txbRemarks.Text;
            service.UpdateItem(item);
            RefreshView();
        }
    }
}
