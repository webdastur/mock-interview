import 'dart:async';

import 'package:chopper/chopper.dart';
import 'package:flutter_modular/flutter_modular.dart';
import 'package:mock_interview/core/models/api/auth/login_request/login_request.dart';
import 'package:mock_interview/core/models/api/auth/login_response/login_response.dart';
import 'package:mock_interview/core/models/api/common/app_error.dart';
import 'package:mock_interview/core/services/api/auth_service.dart';

class APIService {
  static APIService get to => Modular.get<APIService>();

  late ChopperClient _client;

  static APIService init() {
    var instance = APIService();

    const converter = JsonSerializableConverter({
      LoginRequest: LoginRequest.fromJsonFactory,
      LoginResponse: LoginResponse.fromJsonFactory,
    });

    instance._client = ChopperClient(
      baseUrl: Uri.parse("http://127.0.0.1:8000/api"),
      services: [
        AuthService.create(),
      ],
      converter: converter,
      errorConverter: converter,
    );

    return instance;
  }

  AuthService get authService => _client.getService<AuthService>();
}

typedef JsonFactory<T> = T Function(Map<String, dynamic> json);

class JsonSerializableConverter extends JsonConverter {
  final Map<Type, JsonFactory> factories;

  const JsonSerializableConverter(this.factories);

  T? _decodeMap<T>(Map<String, dynamic> values) {
    /// Get jsonFactory using Type parameters
    /// if not found or invalid, throw error or return null
    final jsonFactory = factories[T];
    if (jsonFactory == null || jsonFactory is! JsonFactory<T>) {
      /// throw serializer not found error;
      return null;
    }

    return jsonFactory(values);
  }

  List<T> _decodeList<T>(Iterable values) =>
      values.where((v) => v != null).map<T>((v) => _decode<T>(v)).toList();

  dynamic _decode<T>(entity) {
    if (entity is Iterable) return _decodeList<T>(entity as List);

    if (entity is Map) return _decodeMap<T>(entity as Map<String, dynamic>);

    return entity;
  }

  @override
  FutureOr<Response<ResultType>> convertResponse<ResultType, Item>(
    Response response,
  ) async {
    // use [JsonConverter] to decode json
    final jsonRes = await super.convertResponse(response);

    return jsonRes.copyWith<ResultType>(body: _decode<Item>(jsonRes.body));
  }

  @override
  // all objects should implements toJson method
  // ignore: unnecessary_overrides
  Request convertRequest(Request request) => super.convertRequest(request);

  @override
  FutureOr<Response> convertError<ResultType, Item>(Response response) async {
    // use [JsonConverter] to decode json
    final jsonRes = await super.convertError(response);

    return jsonRes.copyWith<AppError>(
      body: AppError.fromJsonFactory(jsonRes.body),
    );
  }
}
