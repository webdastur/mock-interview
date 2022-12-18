import 'package:equatable/equatable.dart';
import 'package:json_annotation/json_annotation.dart';

class AppResponse<T> extends Equatable {
  final List<T>? items;
  @JsonKey(name: 'page_number')
  final int? pageNumber;
  @JsonKey(name: 'total_pages')
  final int? totalPages;
  @JsonKey(name: 'total_count')
  final int? totalCount;
  @JsonKey(name: 'has_pervious_page')
  final bool? hasPerviousPage;
  @JsonKey(name: 'has_next_page')
  final bool? hasNextPage;

  const AppResponse({
    this.items,
    this.pageNumber,
    this.totalPages,
    this.totalCount,
    this.hasPerviousPage,
    this.hasNextPage,
  });

  factory AppResponse.fromJson(Map<String, dynamic> json) {
    return AppResponse(
      items: json['items'],
      pageNumber: json['page_number'],
      totalPages: json['total_pages'],
      totalCount: json['total_count'],
      hasPerviousPage: json['has_pervious_page'],
      hasNextPage: json['has_next_page'],
    );
  }

  @override
  bool get stringify => true;

  @override
  List<Object?> get props {
    return [
      items,
      pageNumber,
      totalPages,
      totalCount,
      hasPerviousPage,
      hasNextPage,
    ];
  }
}
