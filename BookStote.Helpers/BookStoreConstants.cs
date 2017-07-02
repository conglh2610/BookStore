using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStote.Helpers
{
    public class BookStoreConstants
    {
        public const string CONFIRM_DIALOG_NAME = "Confirmation";

        public const string AUTHOR_DIR_PATH = @"\Images\Authors";

        public const string BOOK_DIR_PATH = @"\Images\Books";

        public const string IMAGE_FILETER = "Images only. |*.jpg; *.jpeg; *.png; *.gif";

        public const string MSG_REQUIRED_FIELD = "Please enter the required field.";

        public const string MSG_EMAIL_REQUIRED_FIELD = "Please enter the your email.";

        public const string MSG_PASSWORD_REQUIRED_FIELD = "Please enter the your password.";

        public const string MSG_FORMAT_NUMBER = "Please enter the number.";

        public const string MSG_LOGIN_FAIL = "Your email or password is not correct.";

        public const string MSG_EMAIL_INCORRECTED_FORMAT = "Please enter correct email.";

        public const string MSG_PASSWORD_NOT_MATCH = "Password confirm does not match the password.";

        public const string ADMIN_ROLE_TYPE = "ADMIN";

        public const string USER_ROLE_TYPE = "USER";

        public const string MSG_DB_ERROR = "Error occurred while updating data.";

        public const string MSG_REGISTRY_SUCCESS = "Resigtry user sucessfully.";

        public const string MSG_REGISTRY_DUPPLICATED = "Email address is really existing.";

        public const string MSG_CONFIRM_DELETE = "Are you sure to delete this record?";

        public const string MSG_CATEGORY_CONFIRM_DELETE = "This category is being used. Are you sure to delete?";

        public const string MSG_AUTHOR_CONFIRM_DELETE = "This author is being used. Are you sure to delete?";

        public const string BUTTON_TEXT_UPDATE = "Update";

        public const string BUTTON_TEXT_ADD = "Add";

        public const string BUTTON_TEXT_DELETE = "Delete";
    }
}
