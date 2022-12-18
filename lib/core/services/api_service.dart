import 'dart:convert';

import 'package:flutter_modular/flutter_modular.dart';
import 'package:http/http.dart' as http;

class APIService {
  static APIService get to => Modular.get<APIService>();

  static String baseUrl = "https://localhost:7265/api/";

  static APIService init() {
    var instance = APIService();

    return instance;
  }

  Future<Map<String, dynamic>> getAllInterviewers({
    required int page,
    required int pageSize,
  }) async {
    var response = await http.get(
      Uri.parse(
        "${baseUrl}Users/interviewers?Page=$page&PageSize=$pageSize",
      ),
    );

    return jsonDecode(response.body);
  }

  Future<Map<String, dynamic>> login({
    required String login,
    required String password,
  }) async {
    var response = await http.post(
      Uri.parse(
        "${baseUrl}Tokens",
      ),
      body: {
        "login": login,
        "password": password,
      },
    );

    return jsonDecode(response.body);
  }
}
