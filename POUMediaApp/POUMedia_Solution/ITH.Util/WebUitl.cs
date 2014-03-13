using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Web.UI;


namespace ITH.Library
{
    /// <summary>
    /// Summary description for WebUitl
    /// </summary>
    public static class WebUitl
    {


        /// <summary>
        /// Selects the un select all check box.
        /// </summary>
        /// <param name="value">if set to <c>true</c> [value].</param>
        /// <param name="gridViewToLoop">The grid view to loop.</param>
        /// <param name="checkBoxName">Name of the check box.</param>
        public static void SelectUnSelectAllCheckBoxInsideGridView(bool value, GridView gridViewToLoop, string checkBoxName)
        {
            foreach (GridViewRow rowItem in gridViewToLoop.Rows)
            {
                if (rowItem != null)
                {
                    CheckBox chkBox = (CheckBox)rowItem.FindControl(checkBoxName);

                    if (chkBox != null)
                    {
                        chkBox.Checked = value;
                    }
                }
            }
        }

        /// <summary>
        /// Loads the please select to drop down.
        /// </summary>
        /// <param name="dropdownListControl">The dropdown list control.</param>
        /// <param name="index">The index.</param>
        public static void LoadPleaseSelectToDropDown(DropDownList dropdownListControl, int? index)
        {
            ListItem item = new ListItem();
            item.Text = "Please Select";
            item.Value = "0";

            if (index == null) //if index is null then add it to the top.
            {
                dropdownListControl.Items.Insert(0, item);
            }
            else
            {
                //add to item to the specified index.
                dropdownListControl.Items.Insert(index.Value, item);
            }
        }

        /// <summary>
        /// Selects the drop down item.
        /// </summary>
        /// <param name="dropdownListControl">The dropdown list control.</param>
        /// <param name="value">The value.</param>
        public static void SelectDropDownItem(DropDownList dropdownListControl, int value)
        {
            if (dropdownListControl == null)
            {
                throw new ArgumentNullException("Drop down control can not be null.");
            }

            dropdownListControl.ClearSelection();//clear existing selection.
            //find the value in the drop down item.
            ListItem item = dropdownListControl.Items.FindByValue(value.ToString());

            if (item == null) //if item is null return to called method.
            {
                return;
            }

            item.Selected = true;
        }

        /// <summary>
        /// Strips the HTML tags.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        public static string StripHTMLTags(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                return Regex.Replace(text, @"&amp;lt;(.|\n)*?&amp;gt;", string.Empty);

            }
            return string.Empty;
        }

        /// <summary>
        /// Adds the HTML tags.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        public static string ReplaceHTMLTagsFromEncodedHTMLTags(string text)
        {
            string htmlStringToReturn = string.Empty;

            if (!string.IsNullOrEmpty(text))
            {

                htmlStringToReturn = Regex.Replace(text, @"&amp;lt;(.|\n)*?", "<");
                htmlStringToReturn = Regex.Replace(htmlStringToReturn, @"&amp;gt;(.|\n)*?", ">");

                htmlStringToReturn = Regex.Replace(htmlStringToReturn, @"&lt;(.|\n)*?", "<");
                htmlStringToReturn = Regex.Replace(htmlStringToReturn, @"&gt;(.|\n)*?", ">");



            }

            return htmlStringToReturn;
        }

        /// <summary>
        /// Gets the value from URL.
        /// </summary>
        /// <param name="urlParam">The URL param.</param>
        /// <returns></returns>
        public static string GetValueFromURL(string urlParam)
        {
            if (!string.IsNullOrEmpty(urlParam) && HttpContext.Current.Request.QueryString[urlParam] != null && HttpContext.Current.Request.QueryString[urlParam].ToString().Length > 0)
            {
                return HttpContext.Current.Request.QueryString[urlParam].ToString();
            }

            return string.Empty;
        }


        

        /// <summary>
        /// Gets the decrypted value from URL.
        /// </summary>
        /// <param name="urlParam">The URL param.</param>
        /// <returns></returns>
        public static string GetDecryptedValueFromURL(string urlParam)
        {
            if (!string.IsNullOrEmpty(urlParam) && HttpContext.Current.Request.QueryString[urlParam] != null && HttpContext.Current.Request.QueryString[urlParam].ToString().Length > 0)
            {
                try
                {
                    return Encryption.Decrypt(HttpContext.Current.Request.QueryString[urlParam].ToString());
                }
                catch (Exception ex)
                {
                    if (ex.GetType().ToString().Equals("System.FormatException"))
                    {
                        return string.Empty;
                    }
                    else
                    {
                        throw ex;
                    }
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Clears all controls.
        /// </summary>
        /// <param name="panel">The panel.</param>
        public static void ClearAllControls(Panel panel)
        {
            if (!panel.HasControls())
            {
                return;
            }


            foreach (Control ct in panel.Controls)
            {

                if (ct.GetType() == typeof(TextBox))
                {
                    TextBox control = (TextBox)ct;
                    control.Text = string.Empty;
                }

                if (ct.GetType() == typeof(DropDownList))
                {
                    DropDownList control = (DropDownList)ct;
                    control.ClearSelection();
                }

                if (ct.GetType() == typeof(RadioButtonList))
                {
                    RadioButtonList control = (RadioButtonList)ct;
                    control.ClearSelection();
                }
            }
        }


        /// <summary>
        /// Enables the and disable all controls.
        /// </summary>
        /// <param name="panel">The panel.</param>
        /// <param name="enable">if set to <c>true</c> [enable].</param>
        public static void EnableAndDisableAllControls(Panel panel, bool enable)
        {
            if (!panel.HasControls())
            {
                return;
            }


            foreach (Control ct in panel.Controls)
            {
                if (ct.GetType() == typeof(TextBox))
                {
                    TextBox control = (TextBox)ct;
                    control.Enabled = enable;
                }

                if (ct.GetType() == typeof(RadioButtonList))
                {
                    RadioButtonList control = (RadioButtonList)ct;
                    control.Enabled = enable;
                }


                if (ct.GetType() == typeof(RadioButton))
                {
                    RadioButton control = (RadioButton)ct;
                    control.Enabled = enable;
                }


                if (ct.GetType() == typeof(DropDownList))
                {
                    DropDownList control = (DropDownList)ct;
                    control.Enabled = enable;
                }
            }
        }
    }
}
