#version 330 core

layout(location = 0) in vec2 Position;
layout(location = 1) in vec2 Uv;

out struct VertexOut
{
	vec2 Position;
	vec2 Uv;
} o;

uniform mat2 MODEL;
uniform vec2 POS;
uniform mat4 OTHRO;

vec4 ObjectToWorld(vec2 pos)
{
	pos = MODEL * pos;
	pos += POS;
	vec4 position = OTHRO * vec4(pos,0,1);
	return position;
}

void main()
{
	gl_Position = ObjectToWorld(Position);
	o.Position = Position;
	o.Uv = Uv;
}