
namespace TurrantKar.DTO
{
    /// <summary>
    /// This class is a DTO for response of the API.
    /// </summary>
    public class ResponseModelDTO
    {
        /// <summary>
        /// Entity identityfier for the entity on which operation is performed.
        /// </summary>
        public int Id;

        /// <summary>
        /// Success flag.
        /// </summary>
        public bool IsSuccess = true;

        /// <summary>
        /// Additional message.
        /// </summary>
        public string Message = "";
    }
}
