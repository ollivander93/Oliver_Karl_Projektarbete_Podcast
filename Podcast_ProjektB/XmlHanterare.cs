using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml;
using System.Xml.Linq;

namespace Podcast_ProjektB
{
    class XmlHanterare
    {
        private Datalager data;
        public XmlHanterare()
        {
            data = new Datalager();
        }

        private void populateNodes(TreeViewItem treeNode, XElement xmlElement)
        {
            foreach (XNode child in xmlElement.Nodes())
            {
                switch (child.NodeType)
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

        public void populateTreeView(TreeView treeView)
        {
            XDocument xDoc = data.getXdocument(@"C:\Users\Oliver\Documents\GitHub\Oliver_Karl_Projektarbete_Podcast\Podcast_ProjektB\bin\Debug\podcasts.xml");
            TreeViewItem node = new TreeViewItem
            {
                Header = xDoc.Root.Name.LocalName,
                IsExpanded = true
            };

            treeView.Items.Add(node);
            populateNodes(node, xDoc.Root);

        }
    }
}
