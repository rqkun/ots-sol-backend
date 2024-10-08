﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Common.ErrorHandle
{
    //internal class ErrorMessages
    public class ErrorMessages
    {
        public static class ExceptionMessages
        {
            #region User
            public const string WrongPassword = "Wrong password.";
            #endregion
        }
        public static class SuccessMessages
        {
            #region User
            public const string Login = "Login success.";
            #endregion
        }

        public static class MissingFieldMessage
        {
            #region Util
            public const string MissingFile = "File is not choose.";
            #endregion
        }

        public static class DuplicateMessage
        {
            #region Role
            public const string DuplicateRoleName = "Role name is already exist.";
            #endregion
        }

        public static class KeyNotFoundMessage
        {
            public const string UserNotFound = "User does not exist.";
            public const string SubmitNotFound = "Submit does not exist.";
            public const string BlacklistNotFound = "Blacklist entry does not exist.";
            public const string RoleNotFound = "Role does not exist.";

            #region Test
            public const string TestNotFound = "Test does not exist.";
            #endregion

            #region Answer
            public const string AnswerNotFound = "Answer does not exist.";
            #endregion

            #region Question
            public const string QuestionForTestNotFound = "Question for test does not exist.";
            public const string QuestionNotFound = "Question does not exist.";
            #endregion

            #region Report
            public const string ReportNotFound = "Report does not exist.";
            #endregion
        }
        public static class LoginMessage
        {
            public const string InvalidCredentials = "Invalid Username/Password!";
        }

    }
}
