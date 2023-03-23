namespace BAS24.Api.Kafka.Constants;

public static class KafkaTopics
{
  public static string CreateStore => "create_store";
  public static string UpdateStore => "update_store";
  public static string DeleteStore => "delete_store";
  public static string AddMemberToStore => "add_member_to_store";
  public static string RemoveStoreMember => "remove_store_member";
  public static string UpdateStoreMember => "update_store_member";
  public static string UpdateStoreMemberPermission => "update_store_member_permission";
}
