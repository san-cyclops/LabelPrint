using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using ERP.Notification;
using System.Windows;
using System.Resources;
using System.Collections;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Threading;
using System.Globalization;



namespace ERP.Utility
{
    public static class Toast
    {
        public enum messageType
        {
            Error,
            Warning,
            Information,
            Question
        }

        public enum messageAction
        {
            Save,
            SaveTransaction,
            PauseTransaction,
            Process,
            Modify,
            Delete,
            ValidateFailedOnDelete,
            ExistRecord,
            ExistsForSelected,
            NotExists,
            NotExistsForSelected,
            NotExistsSave,
            NotSelected,
            General,
            Length,
            ValidationFailed,
            Exceed,
            Generate,
            Invalid,
            Print,
            OverwriteQty,
            ConfirmTransaction,
            SubTotalDiscountPercentageExceed,
            SubTotalDiscountAmountExceed,
            ProductDiscountAmountExceedMinimum,
            ProductDiscountPercentageExceed,
            ProductDiscountAmountExceed,
            QtyExceed,
            BatchQtyExceed,
            InvalidSystemDate,
            InvalidDate,
            InvalidDateRange,
            AccessDenied,
            NotFound,
            ZeroAmount,
            ZeroQty,
            InvalidTelephoneNumber,
            InvalidEmailAddress,
            GreaterThan,
            ConfirmPassword,
            Saved,
            Empty,
            ExitSystem,
            AlreadyExists,
            Permission,
            Advancepayment,
            Overpayment,
            Cancel,
            AutoSettlement,
            ShouldBeGreaterThan,
            ShouldBeLesserThan,
            ViewTransaction,
            ChangeMode,
            NotExistsForEntry,
            AllowedInHeadOffice,
            AllowedInOutlet,
            PendingDevelopment

        }

        public static DialogResult Show(string FormName, string displayCode, string displayDescription, messageType MessageType, messageAction MessageAction, string optionalDisplayMessage = "")
        {
            try
            {
                string displayMessage;
                if ((displayCode != "") && (displayDescription != ""))
                {
                    displayMessage = displayCode + " - " + displayDescription.ToLower(); //Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(displayDescription.ToLower()); //Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(displayDescription.ToLower());
                }
                else
                {
                    if (displayCode != "")
                    {
                        displayMessage = displayCode;
                    }
                    else if (displayDescription != "")
                    {
                        displayMessage = displayDescription;
                    }
                    else
                    {
                        displayMessage = "";
                    }

                }

                string message = string.Empty;
                DialogResult dialogResult = DialogResult.No;

                if (MessageAction == messageAction.Save)
                {
                    if (MessageType == messageType.Question)
                        message = "Do you want to save " + displayMessage + " ?";
                    else if (MessageType == messageType.Information)
                        message = displayMessage + "\nsuccessfully saved.\n" + "Do you want to create a new record?";
                }
                else if (MessageAction == messageAction.Process)
                {
                    if (MessageType == messageType.Question)
                        message = "Do you want to Process " + displayMessage + " ?";
                    else if (MessageType == messageType.Information)
                        message = displayMessage + "\nsuccessfully Processed.";
                    else if (MessageType == messageType.Error)
                        message = displayMessage + "\nnot Processed.";
                }

                else if (MessageAction == messageAction.SaveTransaction)
                {
                    if (MessageType == messageType.Question)
                        message = "Do you want to save " + displayMessage + " ?";
                    else if (MessageType == messageType.Information)
                        message = displayMessage + "\nsuccessfully saved.";
                    else if (MessageType == messageType.Error)
                        message = displayMessage + "\nnot saved.";
                }
                else if (MessageAction == messageAction.Print)
                {
                    if (MessageType == messageType.Question)
                        message = "Do you want to print " + displayMessage + " ?";
                    else if (MessageType == messageType.Information)
                        message = displayMessage + "\nsuccessfully printed.";
                    else if (MessageType == messageType.Error)
                        message = displayMessage + "\nnot printed.";

                }
                else if (MessageAction == messageAction.PauseTransaction)
                {
                    if (MessageType == messageType.Question)
                        message = "Do you want to pause " + displayMessage + " ?";
                    else if (MessageType == messageType.Information)
                        message = displayMessage + "\nsuccessfully paused.";
                    else if (MessageType == messageType.Error)
                        message = displayMessage + "\nnot paused.";

                }
                else if (MessageAction == messageAction.Modify)
                {
                    if (MessageType == messageType.Question)
                        message = "Do you want to modify " + displayMessage + " ?";
                    else
                        message = displayMessage + "\nsuccessfully modified.";

                }
                else if (MessageAction == messageAction.ConfirmTransaction)
                {
                    if (MessageType == messageType.Question)
                        message = "Do you want to confirm " + displayMessage + " ?";
                    else if (MessageType == messageType.Information)
                        message = displayMessage + "\nsuccessfully confirmed.";
                    else if (MessageType == messageType.Error)
                        message = displayMessage + "\nnot confirmed.";

                }
                else if (MessageAction == messageAction.ViewTransaction)
                {
                    if (MessageType == messageType.Question)
                        message = "Do you want to view " + displayMessage + " ?";
                    else if (MessageType == messageType.Information)
                        message = displayMessage + "\nsuccessfully viewed.";
                    else if (MessageType == messageType.Error)
                        message = displayMessage + "\nnot viewed.";
                }
                else if (MessageAction == messageAction.ExistRecord)
                {
                    message = displayMessage + " already exists.\nDo you want to modify?";
                }
                else if (MessageAction == messageAction.ExistsForSelected)
                {
                    message = displayMessage + " already exists.\nFor " + optionalDisplayMessage; // pls ckeck this
                }
                else if (MessageAction == messageAction.NotExistsForEntry)
                {
                    message = displayMessage + " Entry record not exists.\n Please verify the available transaction entry setup.";
                }
                else if (MessageAction == messageAction.Delete)
                {
                    if (MessageType == messageType.Question)
                        message = "Do you want to delete\n" + displayMessage + "?";
                    else
                        message = displayMessage + "\nsuccessfully deleted.";
                }

                else if (MessageAction == messageAction.Cancel)
                {
                    if (MessageType == messageType.Question)
                        message = "Do you want to cancel " + displayMessage + " ?";
                    else
                        message = displayMessage + "\nsuccessfully cancelled.";
                }
                else if (MessageAction == messageAction.ValidateFailedOnDelete)
                {
                    message = displayMessage + " already exists in " + optionalDisplayMessage + ".\nYou are not allowed to delete this record.";
                }
                else if (MessageAction == messageAction.NotExists)
                {
                    message = displayMessage + " not exists.";

                }
                else if (MessageAction == messageAction.NotExistsForSelected)
                {
                    message = displayMessage + " not exists.\nFor " + optionalDisplayMessage;

                }
                else if (MessageAction == messageAction.NotExistsSave)
                {
                    message = displayMessage + " not exists.\nDo you want to create a new record?";

                }
                else if (MessageAction == messageAction.NotSelected)
                {
                    message = displayMessage + " not selected.";

                }
                else if (MessageAction == messageAction.General)
                {
                    message = displayMessage;
                }
                else if (MessageAction == messageAction.Length)
                {
                    message = "Invalid length for " + displayMessage + ".";
                }
                else if (MessageAction == messageAction.ValidationFailed)
                {
                    message = "Validation failed.\nPlease check values of blinking areas.";
                }
                else if (MessageAction == messageAction.Exceed)
                {
                    message = "You are already exceeded\n" + displayMessage + ".";
                }
                else if (MessageAction == messageAction.Generate)
                {
                    if (MessageType == messageType.Question)
                        message = "Do you want to generate\n" + displayMessage + " ? ";
                    else if (MessageType == messageType.Information)
                        message = displayMessage + "\nsuccessfully generated.";
                }
                else if (MessageAction == messageAction.Invalid)
                {
                    message = displayMessage + " is invalid." + optionalDisplayMessage;
                }
                else if (MessageAction == messageAction.OverwriteQty)
                {
                    message = "Do you want to overwrite the Quantity ?\n if not untick the Overwrite Qty check box and continue";
                }
                else if (MessageAction == messageAction.SubTotalDiscountPercentageExceed)
                {
                    message = "Sub total discount percentage cannot exceed 100";
                }
                else if (MessageAction == messageAction.SubTotalDiscountAmountExceed)
                {
                    message = "The Subtotal discount amount cannot exceed the Gross amount";
                }
                else if (MessageAction == messageAction.ProductDiscountAmountExceedMinimum)
                {
                    message = "The Product discount amount cannot exceed the Minimum price";
                }
                else if (MessageAction == messageAction.ProductDiscountPercentageExceed)
                {
                    message = "The Product discount percentage cannot exceed 100";
                }
                else if (MessageAction == messageAction.ProductDiscountAmountExceed)
                {
                    message = "The Product discount amount should be lesser than the Price of the product";
                }
                else if (MessageAction == messageAction.QtyExceed)
                {
                    message = displayMessage + "Available quantity is lesser than entered.\nPlease enter a lesser quantity\nor contact system administrator to allow minus";
                }
                else if (MessageAction == messageAction.InvalidDate)
                {
                    message = "Please select a valid date";
                }
                else if (MessageAction == messageAction.InvalidDateRange)
                {
                    message = "Please select a valid date range";
                }
                else if (MessageAction == messageAction.InvalidSystemDate)
                {
                    message = "Please check Transaction/System date. \nTransaction/System date does not exist within the financial period.";
                }
                else if (MessageAction == messageAction.AccessDenied)
                {
                    if (MessageType == messageType.Information)
                    { message = "Access denied -" + displayMessage; }
                    else if (MessageType == messageType.Warning)
                    { message = displayMessage; }
                    else
                        message = displayMessage;

                }
                else if (MessageAction == messageAction.NotFound)
                {
                    message = displayMessage + " not found.";

                }
                else if (MessageAction == messageAction.ZeroAmount)
                {
                    message = displayMessage + " can not be zero.";

                }
                else if (MessageAction == messageAction.ZeroQty)
                {
                    message = displayMessage + " can not be zero.";
                }
                else if (MessageAction == messageAction.InvalidTelephoneNumber)
                {
                    message = "Please enter a valid phone number.";
                }
                else if (MessageAction == messageAction.InvalidEmailAddress)
                {
                    message = "Please enter a valid email address.";
                }
                else if (MessageAction == messageAction.GreaterThan)
                {
                    message = string.Format("{0} cannot be greater than {1}.", displayMessage, optionalDisplayMessage);
                }
                else if (MessageAction == messageAction.ShouldBeGreaterThan)
                {
                    message = string.Format("{0} should be greater than {1}.", displayMessage, optionalDisplayMessage);
                }
                else if (MessageAction == messageAction.ShouldBeLesserThan)
                {
                    message = string.Format("{0} should be lesser than {1}.", displayMessage, optionalDisplayMessage);
                }
                else if (MessageAction == messageAction.ConfirmPassword)
                {
                    message = "The password and confirmation password do not match ";
                }
                else if (MessageAction == messageAction.Saved)
                {
                    message = "Successfully saved";
                }
                else if (MessageAction == messageAction.Empty)
                {
                    message = displayMessage + " cannot be empty";
                }
                else if (MessageAction == messageAction.ExitSystem)
                {
                    message = "Are you sure you want to exit ?";
                }
                else if (MessageAction == messageAction.AlreadyExists)
                {
                    message = displayMessage + " already exists" + optionalDisplayMessage;
                }
                else if (MessageAction == messageAction.PendingDevelopment)
                {
                    message = displayMessage + "Development Still Not complete " + optionalDisplayMessage; //////////// Check this//////
                }
                else if (MessageAction == messageAction.Permission)
                {
                    message = "You do not have privilege to modify this \n" + displayMessage;
                }
                else if (MessageAction == messageAction.Advancepayment)
                {
                    if (MessageType == messageType.Question)
                        message = "Do you want to do an advance payment ?\n" + displayMessage;
                    else if (MessageType == messageType.Information)
                        message = displayMessage + "\nrecord added successfully";
                }
                else if (MessageAction == messageAction.Overpayment)
                {
                    if (MessageType == messageType.Question)
                        message = "Do you want to do an overpayment ?\n" + displayMessage;
                    else if (MessageType == messageType.Information)
                        message = displayMessage + "\nrecord added successfully";
                }
                else if (MessageAction == messageAction.AutoSettlement)
                {
                    if (MessageType == messageType.Question)
                        message = "Do you want to apply auto settlement for this payment ?\n" + displayMessage;
                    else if (MessageType == messageType.Information)
                        message = displayMessage + "\nrecord added successfully";
                }
                else if (MessageAction == messageAction.ChangeMode)
                {
                    if (MessageType == messageType.Question)
                        message = (string.IsNullOrEmpty(optionalDisplayMessage) ? string.Empty : optionalDisplayMessage + "\n") + "Do you want to change mode " + displayMessage + " ?\n";
                }

                else if (MessageAction == messageAction.AllowedInHeadOffice)   // Display msg wheave an IsAllowedInHeadOffice == false
                {
                    message = displayMessage;//"You do not have previledge to perform this task. \nPlease contact administrator";
                }

                else if (MessageAction == messageAction.AllowedInOutlet)   // Display msg when IsAllowedInHeadOffice == false
                {
                    message = displayMessage; // "You do not have previledge to perform this task. \nPlease contact administrator";
                }

                if ((FormName == "") || (FormName == string.Empty))   // Display RIT ERp on the msgbox title, if formname is empty
                {
                    FormName = "RIT ERP " + Common.Version;
                }

                switch (MessageType)
                {
                    case messageType.Error:
                        {
                            if (message.Equals(string.Empty))
                            {
                                message = "Error Found.";
                            }

                            //return MessageBox.Show(message, FormName , MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return FrmMessageBox.ShowMsg(message, FormName, ERPMessageBoxBtn.OK, ERPMessageBoxIcon.ERROR);
                        }

                    case messageType.Warning:
                        return FrmMessageBox.ShowMsg(message, FormName, ERPMessageBoxBtn.OK, ERPMessageBoxIcon.CAUTION);
                    case messageType.Information:
                        if (MessageAction == messageAction.Save)
                            //return MessageBox.Show(message, "RIT ERP " + Common.Version, MessageBoxButtons.YesNo, MessageBoxIcon.Question);     Old Msg
                            //return MessageBox.Show(message, FormName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            return FrmMessageBox.ShowMsg(message, FormName, ERPMessageBoxBtn.YES_NO, ERPMessageBoxIcon.QUESTION);
                        else
                        {
                            //return MessageBox.Show(message, "RIT ERP " + Common.Version, MessageBoxButtons.OK, MessageBoxIcon.Information);    Old Msg
                            //return MessageBox.Show(message, FormName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return FrmMessageBox.ShowMsg(message, FormName, ERPMessageBoxBtn.OK, ERPMessageBoxIcon.INFO);
                        }
                    case messageType.Question:
                        MessageBoxDefaultButton defaultButton = new MessageBoxDefaultButton();

                        if (MessageAction == messageAction.Delete)
                        { defaultButton = MessageBoxDefaultButton.Button2; }
                        else if (MessageAction == messageAction.Overpayment)
                        {
                            defaultButton = MessageBoxDefaultButton.Button2;
                        }
                        else if (MessageAction == messageAction.Advancepayment)
                        {
                            defaultButton = MessageBoxDefaultButton.Button2;
                        }
                        else if (MessageAction == messageAction.AutoSettlement)
                        {
                            defaultButton = MessageBoxDefaultButton.Button2;
                        }
                        else if (MessageAction == messageAction.ChangeMode)
                        {
                            defaultButton = MessageBoxDefaultButton.Button2;
                        }

                        //return MessageBox.Show(message, "ERP " + Common.Version, MessageBoxButtons.YesNo, MessageBoxIcon.Question, defaultButton);   Old Msg
                        //return MessageBox.Show(message, FormName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, defaultButton);
                        return FrmMessageBox.ShowMsg(message, FormName, ERPMessageBoxBtn.YES_NO, ERPMessageBoxIcon.QUESTION);
                    default:
                        return dialogResult;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Common.Version, MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult dialogResultErr = DialogResult.No;
                return dialogResultErr;
            }
        }

        public static void ShowToast(string x)
        {
            Form frmToast = new Form();
        }

    }
}
