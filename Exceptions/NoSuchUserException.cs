namespace CodingChallenge.Exceptions
{
    public class NoSuchUserException:Exception
    {
        private readonly string message;
        public NoSuchUserException()
        {
            message = "No User Found with given id";
        }
        public override string Message => message;
    }
}
