//===============================================================================
/* Copyright © 2021 ThinkAI (). All Rights Reserved.
* Unauthorized copying of this file, via any medium is strictly prohibited
* Proprietary and confidential
* 
* Author: Atul Badgujar <atul.badgujar2@gmail.com>
* Date: 05 April 2021
* 
* Contributor/s: 
* Last Updated On: 05 April 2021*/
//===============================================================================

using System;
using System.Collections.Generic;

namespace TurrantKar.EH {

    /// <summary>
    /// It is a base exception class inherited from System.ApplicationException class.
    /// All other custom exception will be inherited from this class.
    /// </summary>
    [Serializable]
    public abstract class BaseException : System.ApplicationException {

        #region Local Members

        private static readonly string _message = "An exception occurred.";

        #endregion Local Members

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the BaseException class.
        /// </summary>
        public BaseException()
            : base(_message) {
        }

        /// <summary>
        /// Initializes a new instance of the BaseException class with a specified error message.
        /// </summary>
        /// <param name="message">The error message that describe the error.</param>
        public BaseException(string message)
            : base(message) {
        }

        /// <summary>
        /// Initializes a new instance of the BaseException class with a specified error message
        /// and a reference to the inner exception that is the cause of this exception.
        /// </summary>   
        /// <param name="inner">
        /// The exception that is the cause of the current exception, or a null reference
        /// if no inner exception is specified.
        /// </param>
        public BaseException(System.Exception inner)
            : base(_message, inner) {
            if (inner != null)
                ExceptionUtils.MarkAsWrapper(inner);
        }


        /// <summary>
        /// Initializes a new instance of the BaseException class with a specified error message
        /// and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that describe the error.</param>
        /// <param name="inner">
        /// The exception that is the cause of the current exception, or a null reference
        /// if no inner exception is specified.
        /// </param>
        public BaseException(string message, System.Exception inner)
            : base(message, inner) {
            if (inner != null)
                ExceptionUtils.MarkAsWrapper(inner);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Add extra information in excetpion.
        /// </summary>
        /// <param name="key">Extra information key.</param>
        /// <param name="data">Extra information of.</param>    
        public virtual void SetData(string key, object data) {
            // This test is done to protect from the error of re-addition of a key.
            // We will overwite the data. This is an arbitrary decision.
            if (this.Data.Contains(key))
                this.Data[key] = data;
            else
                this.Data.Add(key, data);
        }

        /// <summary>
        /// Get extra information from exception.
        /// </summary>
        /// <param name="key">Extra information key.</param>
        /// <returns>Entity object.</returns>
        public object GetData(string key) {
            object data = null;
            if (this.Data.Contains(key))
                data = this.Data[key];

            return data;
        }

        #endregion Public Methods

        #region Public Property

        /// <summary>
        /// Property to Get or Set list of error data.
        /// </summary>
        public IList<TKErrorData> ErrorDataList {
            get;
            set;
        }

        /// <summary>
        /// Gets the type of the TK error.
        /// </summary>
        /// <value>
        /// The type of the TK error.
        /// </value>
        public abstract ErrorType GetTKErrorType();
     

        private TKError _TKError;
        /// <summary>
        /// Gets the TK error.
        /// </summary>
        /// <value>
        /// The TK error.
        /// </value>
        public TKError TKError {
            get {
                if (_TKError == null) {
                    InitTKEror();
                }
                return _TKError;
            }
            private set{}
        }

        #endregion Public Property


        #region Private Methods

        /// <summary>
        /// Initializes the TK eror.
        /// </summary>
        private void InitTKEror() {
            _TKError = new TKError() {
                //ErrorType = TKErrorType,
                MessageList = new List<string>() { Convert.ToString(_message) },
                TKErrorDataList = ErrorDataList
            };
        }
        #endregion Private Methods     
    }
}
