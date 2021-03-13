#version 330 core
in struct VertexOut
{
	vec3 Position;
	vec3 Normal;
	vec4 Color;
	vec2 Uv;
} o;

uniform sampler2D Main;
out vec4 glFragColor;

void main()
{
	glFragColor = texture(Main, o.Uv);
	glFragColor = vec4(1);
}