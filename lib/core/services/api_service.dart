import 'dart:async';
import 'dart:convert';

import 'package:flutter_modular/flutter_modular.dart';
import 'package:http/http.dart' as http;
import 'package:mock_interview/core/services/hive_service.dart';

class APIService {
  static APIService get to => Modular.get<APIService>();

  static String baseUrl = "https://localhost:7265/api/";

  static APIService init() {
    var instance = APIService();

    return instance;
  }

  Map<String, String> getHeaders() {
    return {"Authorization": "Bearer ${HiveService.to.getToken()}"};
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

  Future<Map<String, dynamic>> getAllUsers({
    required int page,
    required int pageSize,
  }) async {
    var response = await http.get(
      Uri.parse(
        "${baseUrl}Users/list?Page=$page&PageSize=$pageSize",
      ),
      headers: getHeaders(),
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
      headers: {'Content-Type': 'application/json'},
      body: jsonEncode({
        "login": login,
        "password": password,
      }),
    );

    return jsonDecode(response.body);
  }

  Future<void> deleteUser(int id) async {
    var response = await http.delete(
      Uri.parse(
        "${baseUrl}Users/$id",
      ),
      headers: {
        'Content-Type': 'application/json',
        "Authorization": "Bearer ${HiveService.to.getToken()}"
      },
    );

    return jsonDecode(response.body);
  }
}
