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
        private RssHanterare rss;
        private XmlHanterare xmlhant;
        public MainWindow()
        {
            InitializeComponent();
            xmlhant = new XmlHanterare();
            populateTree();
            rss = new Podcast_ProjektB.RssHanterare("url", "name");
            rss.getFeed();
            loadPodcasts();
        }

        private void populateTree()
        {
            xmlhant.populateTreeView(treeView1);
        }

        private void loadPodcasts()
        {
            List<Podcast> podcasts = rss.getFeed();
            foreach(Podcast pod in podcasts)
            {
                ListBoxItem item = new ListBoxItem();
                item.Tag = pod.getSubject();
                podcastList.Items.Add(pod.getSubject());
            }
        }

        private void OnTreeViewSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            TreeViewItem item = treeView1.ItemContainerGenerator.ContainerFromItem(SelectedItem) as TreeViewItem;
        }
    } 
    
    }
