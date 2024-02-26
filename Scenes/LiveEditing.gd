extends MeshInstance3D

var vis = [true, true, true, true, true, true]
var idx = 0;
var vertices = PackedVector3Array()
var normals = PackedVector3Array()
var uv = PackedVector2Array()
var uv2 = PackedVector2Array()
var indices = PackedInt32Array()

var thread

func _ready():
	#thread = Thread.new()
	#thread.start(self, "make_mesh")
	make_mesh()
	
func _exit_tree():
	pass
	#thread.wait_to_finish()
	
func _process(_delta):
	if (Input.is_action_just_pressed("test_key")):
		try_remove()
		#thread = Thread.new()
		#thread.start(self, "try_remove")
	pass
	
func try_remove():
	
	for n in range(indices.size()-1,indices.size()-37, -1):
		indices.remove(n)
		normals.remove(n)
		uv.remove(n)
		uv2.remove(n)
		vertices.remove(n)
		
	
	var arr_mesh = ArrayMesh.new()	
	var arrays = []
	arrays.resize(ArrayMesh.ARRAY_MAX)
	arrays[ArrayMesh.ARRAY_VERTEX] = vertices
	arrays[ArrayMesh.ARRAY_NORMAL] = normals
	arrays[ArrayMesh.ARRAY_TEX_UV] = uv
	arrays[ArrayMesh.ARRAY_TEX_UV2] = uv2
	arrays[ArrayMesh.ARRAY_INDEX] = indices;
	
	arr_mesh.add_surface_from_arrays(Mesh.PRIMITIVE_TRIANGLES, arrays)
	mesh = arr_mesh
	
func make_mesh():
	
	for i in range(0,180):
		for j in range(0,180):
			make_faces(Vector3(i,0,j))
	
	var arr_mesh = ArrayMesh.new()
	var arrays = []
	arrays.resize(ArrayMesh.ARRAY_MAX)
	arrays[ArrayMesh.ARRAY_VERTEX] = vertices
	arrays[ArrayMesh.ARRAY_NORMAL] = normals
	arrays[ArrayMesh.ARRAY_TEX_UV] = uv
	arrays[ArrayMesh.ARRAY_TEX_UV2] = uv2
	arrays[ArrayMesh.ARRAY_INDEX] = indices
	
	arr_mesh.add_surface_from_arrays(Mesh.PRIMITIVE_TRIANGLES, arrays)
	mesh = arr_mesh

func make_faces(pos: Vector3, s := .6): 
	if (vis[0]):
		vertices.push_back(Vector3(0,s,0) + pos)
		normals.push_back(Vector3(0,0,0))
		uv.push_back(Vector2(0,0))
		uv2.push_back(Vector2(0,0))
		indices.push_back(idx)
		idx += 1
		
		vertices.push_back(Vector3(0,0,s) + pos)
		normals.push_back(Vector3(0,0,0))
		uv.push_back(Vector2(0,0))
		uv2.push_back(Vector2(0,0))
		indices.push_back(idx)
		idx += 1
		
		vertices.push_back(Vector3(0,0,0) + pos)
		normals.push_back(Vector3(0,0,0))
		uv.push_back(Vector2(0,0))
		uv2.push_back(Vector2(0,0))
		indices.push_back(idx)
		idx += 1
		
		vertices.push_back(Vector3(0,s,s) + pos)
		normals.push_back(Vector3(0,0,0))
		uv.push_back(Vector2(0,0))
		uv2.push_back(Vector2(0,0))
		indices.push_back(idx)
		idx += 1
		
		vertices.push_back(Vector3(0,0,s) + pos)
		normals.push_back(Vector3(0,0,0))
		uv.push_back(Vector2(0,0))
		uv2.push_back(Vector2(0,0))
		indices.push_back(idx)
		idx += 1
		
		vertices.push_back(Vector3(0,s,0) + pos)
		normals.push_back(Vector3(0,0,0))
		uv.push_back(Vector2(0,0))
		uv2.push_back(Vector2(0,0))
		indices.push_back(idx)
		idx += 1
	if (vis[1]):
		vertices.push_back(Vector3(s,0,s) + pos)
		normals.push_back(Vector3(0,0,0))
		uv.push_back(Vector2(0,0))
		uv2.push_back(Vector2(0,0))
		indices.push_back(idx)
		idx += 1
		
		vertices.push_back(Vector3(s,s,0) + pos)
		normals.push_back(Vector3(0,0,0))
		uv.push_back(Vector2(0,0))
		uv2.push_back(Vector2(0,0))
		indices.push_back(idx)
		idx += 1
		
		vertices.push_back(Vector3(s,0,0) + pos)
		normals.push_back(Vector3(0,0,0))
		uv.push_back(Vector2(0,0))
		uv2.push_back(Vector2(0,0))
		indices.push_back(idx)
		idx += 1
		
		vertices.push_back(Vector3(s,s,0) + pos)
		normals.push_back(Vector3(0,0,0))
		uv.push_back(Vector2(0,0))
		uv2.push_back(Vector2(0,0))
		indices.push_back(idx)
		idx += 1
		
		vertices.push_back(Vector3(s,0,s) + pos)
		normals.push_back(Vector3(0,0,0))
		uv.push_back(Vector2(0,0))
		uv2.push_back(Vector2(0,0))
		indices.push_back(idx)
		idx += 1
		
		vertices.push_back(Vector3(s,s,s) + pos)
		normals.push_back(Vector3(0,0,0))
		uv.push_back(Vector2(0,0))
		uv2.push_back(Vector2(0,0))
		indices.push_back(idx)
		idx += 1
	if (vis[2]):
		vertices.push_back(Vector3(s,0,s) + pos)
		normals.push_back(Vector3(0,0,0))
		uv.push_back(Vector2(0,0))
		uv2.push_back(Vector2(0,0))
		indices.push_back(idx)
		idx += 1
		
		vertices.push_back(Vector3(s,0,0) + pos)
		normals.push_back(Vector3(0,0,0))
		uv.push_back(Vector2(0,0))
		uv2.push_back(Vector2(0,0))
		indices.push_back(idx)
		idx += 1
		
		vertices.push_back(Vector3(0,0,0) + pos)
		normals.push_back(Vector3(0,0,0))
		uv.push_back(Vector2(0,0))
		uv2.push_back(Vector2(0,0))
		indices.push_back(idx)
		idx += 1
		
		vertices.push_back(Vector3(0,0,0) + pos)
		normals.push_back(Vector3(0,0,0))
		uv.push_back(Vector2(0,0))
		uv2.push_back(Vector2(0,0))
		indices.push_back(idx)
		idx += 1
		
		vertices.push_back(Vector3(0,0,s) + pos)
		normals.push_back(Vector3(0,0,0))
		uv.push_back(Vector2(0,0))
		uv2.push_back(Vector2(0,0))
		indices.push_back(idx)
		idx += 1
		
		vertices.push_back(Vector3(s,0,s) + pos)
		normals.push_back(Vector3(0,0,0))
		uv.push_back(Vector2(0,0))
		uv2.push_back(Vector2(0,0))
		indices.push_back(idx)
		idx += 1
		pass
	if (vis[3]):
		vertices.push_back(Vector3(0,s,0) + pos)
		normals.push_back(Vector3(0,0,0))
		uv.push_back(Vector2(0,0))
		uv2.push_back(Vector2(0,0))
		indices.push_back(idx)
		idx += 1
		
		vertices.push_back(Vector3(s,s,0) + pos)
		normals.push_back(Vector3(0,0,0))
		uv.push_back(Vector2(0,0))
		uv2.push_back(Vector2(0,0))
		indices.push_back(idx)
		idx += 1
		
		vertices.push_back(Vector3(s,s,s) + pos)
		normals.push_back(Vector3(0,0,0))
		uv.push_back(Vector2(0,0))
		uv2.push_back(Vector2(0,0))
		indices.push_back(idx)
		idx += 1
		
		vertices.push_back(Vector3(s,s,s) + pos)
		normals.push_back(Vector3(0,0,0))
		uv.push_back(Vector2(0,0))
		uv2.push_back(Vector2(0,0))
		indices.push_back(idx)
		idx += 1
		
		vertices.push_back(Vector3(0,s,s) + pos)
		normals.push_back(Vector3(0,0,0))
		uv.push_back(Vector2(0,0))
		uv2.push_back(Vector2(0,0))
		indices.push_back(idx)
		idx += 1
		
		vertices.push_back(Vector3(0,s,0) + pos)
		normals.push_back(Vector3(0,0,0))
		uv.push_back(Vector2(0,0))
		uv2.push_back(Vector2(0,0))
		indices.push_back(idx)
		idx += 1
	if (vis[4]):
		vertices.push_back(Vector3(s,0,0) + pos)
		normals.push_back(Vector3(0,0,0))
		uv.push_back(Vector2(0,0))
		uv2.push_back(Vector2(0,0))
		indices.push_back(idx)
		idx += 1
		
		vertices.push_back(Vector3(0,s,0) + pos)
		normals.push_back(Vector3(0,0,0))
		uv.push_back(Vector2(0,0))
		uv2.push_back(Vector2(0,0))
		indices.push_back(idx)
		idx += 1
		
		vertices.push_back(Vector3(0,0,0) + pos)
		normals.push_back(Vector3(0,0,0))
		uv.push_back(Vector2(0,0))
		uv2.push_back(Vector2(0,0))
		indices.push_back(idx)
		idx += 1
		
		vertices.push_back(Vector3(s,s,0) + pos)
		normals.push_back(Vector3(0,0,0))
		uv.push_back(Vector2(0,0))
		uv2.push_back(Vector2(0,0))
		indices.push_back(idx)
		idx += 1
		
		vertices.push_back(Vector3(0,s,0) + pos)
		normals.push_back(Vector3(0,0,0))
		uv.push_back(Vector2(0,0))
		uv2.push_back(Vector2(0,0))
		indices.push_back(idx)
		idx += 1
		
		vertices.push_back(Vector3(s,0,0) + pos)
		normals.push_back(Vector3(0,0,0))
		uv.push_back(Vector2(0,0))
		uv2.push_back(Vector2(0,0))
		indices.push_back(idx)
		idx += 1
		pass
	if (vis[5]):
		vertices.push_back(Vector3(0,0,s) + pos)
		normals.push_back(Vector3(0,0,0))
		uv.push_back(Vector2(0,0))
		uv2.push_back(Vector2(0,0))
		indices.push_back(idx)
		idx += 1
		
		vertices.push_back(Vector3(0,s,s) + pos)
		normals.push_back(Vector3(0,0,0))
		uv.push_back(Vector2(0,0))
		uv2.push_back(Vector2(0,0))
		indices.push_back(idx)
		idx += 1
		
		vertices.push_back(Vector3(s,0,s) + pos)
		normals.push_back(Vector3(0,0,0))
		uv.push_back(Vector2(0,0))
		uv2.push_back(Vector2(0,0))
		indices.push_back(idx)
		idx += 1
		
		vertices.push_back(Vector3(s,0,s) + pos)
		normals.push_back(Vector3(0,0,0))
		uv.push_back(Vector2(0,0))
		uv2.push_back(Vector2(0,0))
		indices.push_back(idx)
		idx += 1
		
		vertices.push_back(Vector3(0,s,s) + pos)
		normals.push_back(Vector3(0,0,0))
		uv.push_back(Vector2(0,0))
		uv2.push_back(Vector2(0,0))
		indices.push_back(idx)
		idx += 1
		
		vertices.push_back(Vector3(s,s,s) + pos)
		normals.push_back(Vector3(0,0,0))
		uv.push_back(Vector2(0,0))
		uv2.push_back(Vector2(0,0))
		indices.push_back(idx)
		idx += 1
	pass
