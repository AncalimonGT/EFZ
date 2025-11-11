shader_type canvas_item;

// 以整数(0~255)传入要丢弃的颜色 RGB
uniform ivec3 discard_rgb = ivec3(255, 0, 255);
// 分通道整数容差(0~255)，越小越严格
uniform ivec3 tolerance_rgb = ivec3(16, 8, 16); // 示例：约等于 (0.06, 0.03, 0.06)

// 可选：是否同时匹配 Alpha（关闭时忽略透明度）
uniform bool use_alpha = false;
uniform int discard_a = 255;
uniform int tolerance_a = 0;

void fragment() {
    vec4 color = texture(TEXTURE, UV);

    // 将采样到的颜色转换为 0~255 整数（加 0.5 做四舍五入）
    ivec3 cur = ivec3(
        int(color.r * 255.0 + 0.5),
        int(color.g * 255.0 + 0.5),
        int(color.b * 255.0 + 0.5)
    );
    int cur_a = int(color.a * 255.0 + 0.5);

    bool match_rgb =
        abs(cur.r - discard_rgb.r) <= tolerance_rgb.r &&
        abs(cur.g - discard_rgb.g) <= tolerance_rgb.g &&
        abs(cur.b - discard_rgb.b) <= tolerance_rgb.b;

    bool match_a = !use_alpha ||
        (abs(cur_a - discard_a) <= tolerance_a);

    if (match_rgb && match_a) {
        discard;
    }

    COLOR = color;
}