namespace BAS24.Product.Core.Kafka.Constants;

public static class KafkaTopics
{
  public static string CreateStore => "create_store";
  public static string UpdateStore => "update_store";
  public static string DeleteStore => "delete_store";
  public static string AddMemberToStore => "add_member_to_store";
  public static string RemoveStoreMember => "remove_store_member";
  public static string UpdateStoreMemberPermission => "update_store_member_permission";
}

public static class KafkaGroupIds
{
  public static string CreateStore => "create_store_group";
  public static string UpdateStore => "update_store_group";
  public static string DeleteStore => "delete_store_group";
  public static string AddMemberToStore => "add_member_to_store_group";
  public static string RemoveStoreMember => "remove_store_member_group";
  public static string UpdateStoreMemberPermission => "update_store_member_permission_group";
}