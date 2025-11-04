shader_type canvas_item;

 

void fragment() {
    	
	vec4 color = texture(TEXTURE, UV);
    
	if(abs(color.r-1.0)<0.1&& color.g ==0.0&& abs(color.b-1.0)<0.0001)
    {
		discard;
	}
	else
	{
			
	COLOR = color;
 
}
}