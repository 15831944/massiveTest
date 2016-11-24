using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Shared
{
    [DataContract]
    [Serializable, XmlRoot("node")]
    public partial class Node
    {
        public int Cost = -1;

        public Node PreviousNode { get; set; }

        private byte idField;

        private string labelField;

        private byte[] adjacentNodesField;

        [DataMember]
        public byte id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
        [DataMember]
        public string label
        {
            get
            {
                return this.labelField;
            }
            set
            {
                this.labelField = value;
            }
        }
        [DataMember]
        [System.Xml.Serialization.XmlArrayAttribute()]
        [System.Xml.Serialization.XmlArrayItemAttribute("id", IsNullable = false)]
        public byte[] adjacentNodes
        {
            get
            {
                return this.adjacentNodesField;
            }
            set
            {
                this.adjacentNodesField = value;
            }
        }

       
    }
}

