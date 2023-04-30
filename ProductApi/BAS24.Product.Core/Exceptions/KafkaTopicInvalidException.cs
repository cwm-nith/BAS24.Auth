using BAS24.Libs.Exceptions;

namespace BAS24.Product.Core.Exceptions;

public class KafkaTopicInvalidException:BaseException
{
  public override string Code => "kafka_topic_invalid";
}
