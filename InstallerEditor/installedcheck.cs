using System;
using System.Xml;
using System.ComponentModel;

namespace InstallerEditor
{
	/// <summary>
	/// Tag installedcheck
	/// </summary>
	public class installedcheck
	{
		public installedcheck(string p_type)
		{
			m_type = p_type;
		}

		#region Attributi
		private string m_type; //can be check_registry_value or check_file
		[Description("Type of the check, can be 'check_registry_value' to check for a specific value in the registry or 'check_file' to check for a specific file. (REQUIRED)")]
		public string type
		{
			get{return m_type;}
		}
		#endregion

//		protected void OnDescriptionChanged()
//		{
//			if (DescriptionChanged!=null)
//				DescriptionChanged(this,EventArgs.Empty);
//		}
//
//		public event EventHandler DescriptionChanged;
//

		#region IXmlClass Members

		public void ToXml(XmlWriter p_Writer)
		{
			p_Writer.WriteStartElement("installedcheck");
				p_Writer.WriteAttributeString("type", m_type);
				OnXmlWriteTaginstalledcheck(new XmlWriterEventArgs(p_Writer));
			p_Writer.WriteEndElement();
		}

		public void FromXml(XmlElement p_Element)
		{
			if (p_Element.Attributes["type"] == null ||
				p_Element.Attributes["type"].InnerText != m_type)
				throw new ApplicationException("Invalid type");

			OnXmlReadTaginstalledcheck(new XmlElementEventArgs(p_Element));
		}
		#endregion

		protected virtual void OnXmlWriteTaginstalledcheck(XmlWriterEventArgs e)
		{
		}
		protected virtual void OnXmlReadTaginstalledcheck(XmlElementEventArgs e)
		{
		}

	}

	public enum installcheck_comparison
	{
		match,
		version
	}
}
