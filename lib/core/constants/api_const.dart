class APIConst {
  static const String apiURL = "https://api.uznn.uz";
  static const String checkPhone = "/user/check-phone";
  static const String login = "/user/login";
  static const String verifyPhone = "/user/verify-phone";
  static const String refreshToken = "/user/refresh-token";
  static const String userInfo = "/user/info";
  static const String userUpdate = "/user/update";
  static const String userResend = "/user/resend";
  static const String productList = "/product/list";
  static const String productListByAttribute = "/product/get-by-attribute";
  static const String categoryList = "/category/list";
  static const String categoryListById = "/category/get-by-id";
  static const String categoryGetAttributes = "/category/get-attributes";
  static const String attributeList = "/attribute/list";
  static const String attributeCategoryList = "/attribute-category/list";
  static const String productGetByIds = "/product/get-by-ids";
  static const String getAds = "/ads/get-ads";
  static const String paymentPayToTariff = "/payment/pay-to-tariff";
  static const String paymentGetUrl = "/payment/get-url";
  static const String tariffList = "/tariff/list";
  static const String rateCreate = "/rate/create";
  static const String getNews = "/news/get-news";
  static const String getComments = "/comment/get-comments";
  static const String commentCreate = "/comment/create";
  static const String commentDelete = "/comment/delete";
  static const String currency = "/bank/currencies";

  static String productDetail(int id) => "/product/$id";
}
