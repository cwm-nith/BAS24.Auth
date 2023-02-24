using BAS24.Libs.Exceptions;

namespace BAS24.Api.Exceptions.Users;

public class FieldRequireException : BaseException
{
  public FieldRequireException(string fieldName) : base($"Field {fieldName} require") { }

  public FieldRequireException()
  {
  }

  public FieldRequireException(string message, Exception innerException) : base(message, innerException)
  {
  }

  public override string Code => "field_require";
}
