import 'package:flutter/material.dart';
import 'package:flutter_svg/flutter_svg.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:mock_interview/core/utils/colors.gen.dart';
import 'package:super_rich_text/super_rich_text.dart';

class AppWidgets {
  static Widget text({
    required String text,
    Color color = ColorName.black,
    double fontSize = 16,
    TextDecoration decoration = TextDecoration.none,
    FontWeight fontWeight = FontWeight.w400,
    EdgeInsets padding = const EdgeInsets.all(0),
    TextAlign textAlign = TextAlign.start,
    int maxLines = 3,
    fontStyle = FontStyle.normal,
    bool isRichText = false,
    List<MarkerText> othersMarkers = const [],
    List<String>? args,
    Map<String, String>? namedArgs,
  }) {
    if (isRichText) {
      return Padding(
        padding: padding,
        child: SuperRichText(
          text: text,
          style: GoogleFonts.lato(
            color: color,
            fontSize: fontSize,
            decoration: decoration,
            fontWeight: fontWeight,
          ),
          textAlign: textAlign,
          maxLines: maxLines,
          overflow: TextOverflow.ellipsis,
          othersMarkers: othersMarkers,
        ),
      );
    }
    return Padding(
      padding: padding,
      child: Text(
        text,
        style: GoogleFonts.lato(
          color: color,
          fontSize: fontSize,
          decoration: decoration,
          fontWeight: fontWeight,
        ),
        textAlign: textAlign,
        maxLines: maxLines,
        overflow: TextOverflow.ellipsis,
      ),
    );
  }

  static Widget imageAsset({
    required String image,
    double? height,
    double? width,
  }) {
    if (image.endsWith('.svg')) {
      return SvgPicture.asset(
        image,
        height: height,
        width: width,
      );
    }
    return Image.asset(
      image,
      height: height,
      width: width,
    );
  }
}

Widget appText(
  String text, {
  List<String>? args,
  Map<String, String>? namedArgs,
}) {
  return AppWidgets.text(
    text: text,
    fontWeight: FontWeight.w500,
    color: ColorName.white,
    args: args,
    namedArgs: namedArgs,
  );
}

Widget appTitleText(
  String text, {
  List<String>? args,
  Map<String, String>? namedArgs,
}) {
  return AppWidgets.text(
    text: text,
    fontWeight: FontWeight.w700,
    color: ColorName.white,
    args: args,
    fontSize: 18,
    namedArgs: namedArgs,
  );
}
