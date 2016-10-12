using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using Microsoft.VisualBasic;
using System.Xml;
using System.IO;
using System.Xml.Linq;

namespace Podcast_ProjektB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            populateTreeView(treeView1, XDocument.Load(@"C:\Users\Oliver\Documents\GitHub\Podcast_projektB\Podcast_projekt\bin\Debug\podcasts.xml"));
        }

        private void populateNodes(TreeViewItem treeNode, XElement xmlElement)
        {
            foreach (XNode child in xmlElement.Nodes())
            {
                switch(child.NodeType)
                {
                    case XmlNodeType.Element:
                        XElement childElement = child as XElement;
                        TreeViewItem childTreeNode = new TreeViewItem
                        {
                            Header = childElement.Attributes().First(s => s.Name == "value").Value,
                            IsExpanded = true,
                            Foreground = Brushes.White
                };
                        treeNode.Items.Add(childTreeNode);
                        populateNodes(childTreeNode, childElement);
                        break;

                    case XmlNodeType.Text:
                        XText childText = child as XText;
                        treeNode.Items.Add(new TreeViewItem { Header = childText.Value, });
                        break;
                }
            }
        }

        private void populateTreeView(TreeView treeView, XDocument xDoc)
        {
            TreeViewItem node = new TreeViewItem
            {
                Header = xDoc.Root.Name.LocalName,
                IsExpanded = true
            };

            treeView.Items.Add(node);
            populateNodes(node, xDoc.Root);

            }

        private void AddCategory_Clicked(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = new TreeViewItem();
            item.Header = "Ny";


        }
    } 
    
    }
