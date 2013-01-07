using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Randomize : MonoBehaviour {
	
	public UIButton ResetButton;
	
	//public int numberToSpawn = 100;
	public int maxBoundsOfRandomization = 100;
	//public Texture textureToApplyForTest;
	//public Shader shaderToApplyForTest;
	//public Material[] materialToApplyForTest;
	public Transform centerOfRandomization;
	
	
	public int rockCount;
	public GameObject[] rocks;
	public int treeCount;
	public GameObject[] trees;
	public int vegationCount;
	public GameObject[] vegetation;
	public int monsterCount;
	public GameObject[] monsters;
	
 	List<GameObject> allThingsCreated;
	
	// Use this for initialization
	void Start () 
	{
		ResetButton.disabledColor = Color.black;
		ResetButton.isEnabled = false;
		allThingsCreated = new List<GameObject>();	
		
		
		StartCoroutine(SpacedProcess());
		//allThingsCreated = new GameObject[ vegationCount + rockCount+ treeCount + monsterCount];
	}

	void Reset()
	{
		Destroy(allVeg);
		Destroy(allRocks);
		Destroy(allTrees);
		//StartCoroutine(WaitBeforeContinuing());
		StartCoroutine(SpacedProcess());
		ResetButton.isEnabled = false;
	}
	
	Vector3 GetARandomPosition()
	{
	 	Vector3 randomizedPos;
		
		randomizedPos = new Vector3(Random.Range(centerOfRandomization.position.x, maxBoundsOfRandomization),  //x
			centerOfRandomization.position.y, //y
			Random.Range(centerOfRandomization.position.z, maxBoundsOfRandomization));
		
		return randomizedPos;
	}
	GameObject thing;
//	void CreateRandomObjects(GameObject[] things, int numTimes)
//	{
//		if(things.GetLength(0) > 0)
//		for(int i = 0; i <= numTimes; i++)
//		{
//			
//			thing = GameObject.Instantiate(things[Random.Range(0,things.GetLength(0))]) as GameObject;
//			// Debug.Log(allThingsCreated.Count);
//			//thing.AddComponent<SphereObject>();
//			thing.AddComponent<RandomlyCreatedObject>();
//			thing.isStatic = true;
//			thing.transform.parent = transform;
//			//thing.AddComponent<NavMeshObstacle>();
//			thing.AddComponent<Rigidbody>();
//			//Sphere1.renderer.material.mainTexture = textureToApplyForTest;
//			//if(i % 2 == 0)
//			//thing.renderer.material = materialToApplyForTest[0];
//			//else thing.renderer.material = materialToApplyForTest[1];
//			Vector3 random1 = GetARandomPosition();
//			
//			//Check if on navmesh, if not, randomize again
//			
//			thing.GetComponent<RandomlyCreatedObject>().creator = this;
//			thing.transform.position = random1;
//			
//		   
//		
//		}
//	}
	
	void CreateRandomObject(GameObject original, bool randomRotation, bool oneAxis, GameObject parent)
	{
		thing = GameObject.Instantiate(original) as GameObject;
		Transform t = thing.transform;
		
		thing.AddComponent<RandomlyCreatedObject>();
		thing.isStatic = true;
		t.parent = parent.transform;
		
		thing.AddComponent<Rigidbody>();
		
		Vector3 random1 = GetARandomPosition();
		
		thing.GetComponent<RandomlyCreatedObject>().creator = this;
		t.position = random1;
		
		
		if(randomRotation && !oneAxis)
		{
			Quaternion randomRot = Random.rotation;
			t.rotation = randomRot;
		}else
		{
			Quaternion randomRot = Random.rotation;
			//	randomRot.w = 0;
			randomRot.x = 0;
			randomRot.z = 0;
			t.rotation = randomRot;
		}
		
		allThingsCreated.Add(thing);
	}
	
	
	
//	void CreateRandomObjects(GameObject[] things, int numTimes, bool randomRotation, bool oneAxis, GameObject parent)
//	{
//		if(things.GetLength(0) > 0)
//		for(int i = 0; i <= numTimes; i++)
//		{
//			
//			thing = GameObject.Instantiate(things[Random.Range(0,things.GetLength(0))]) as GameObject;
//			Transform t = thing.transform;
//	
//			thing.AddComponent<RandomlyCreatedObject>();
//			thing.isStatic = true;
//			t.parent = parent.transform;
//			
//			thing.AddComponent<Rigidbody>();
//
//			Vector3 random1 = GetARandomPosition();
//		
//			thing.GetComponent<RandomlyCreatedObject>().creator = this;
//			t.position = random1;
//			
//			
//			if(randomRotation && !oneAxis)
//			{
//				Quaternion randomRot = Random.rotation;
//				t.rotation = randomRot;
//			}else
//			{
//				Quaternion randomRot = Random.rotation;
//			//	randomRot.w = 0;
//				randomRot.x = 0;
//				randomRot.z = 0;
//				t.rotation = randomRot;
//			}
//		   
//			allThingsCreated.Add(thing);
//			
//		}
//	}
	
	//Called by randomized object if in a bad spot
	public void ReRandomize(GameObject go)
	{
		
		go.transform.position = GetARandomPosition();
		//Debug.Log("Randomized " + go + " to : " + go.transform.position);
	}
	GameObject allRocks;
	GameObject allTrees;
	GameObject allVeg;
//	IEnumerator WaitBeforeContinuing()
//	{
//		allRocks = new GameObject();
//		allRocks.name = "AllRocks";
//		CreateRandomObjects(rocks, rockCount, true, false,  allRocks);	
//		yield return new WaitForSeconds(1);
//		Debug.Log(allThingsCreated.Count + " rocks created");
//		allTrees = new GameObject();
//		allTrees.name = "AllTrees";
//		CreateRandomObjects(trees, treeCount, true, true , allTrees);
//		yield return new WaitForSeconds(.5f);
//		Debug.Log(allThingsCreated.Count + " trees created");
//		allVeg = new GameObject();
//		allVeg.name = "AllVeg";
//		CreateRandomObjects(vegetation, vegationCount, false, false, allVeg);
//		yield return new WaitForSeconds(.5f);
//		Debug.Log(allThingsCreated.Count + " veg created");
//		
//		yield return new WaitForSeconds(4);
//		foreach(GameObject go in allThingsCreated)
//		{
//			
//			//if(go.GetComponent<Rigidbody>().IsSleeping() == false)
//			if(go != null)
//			{
//				if(!go.GetComponent<RandomlyCreatedObject>().grounded )
//				{
//					//Debug.Log(go.name + " is not sleeping");
//					Destroy(go);
//					
//				}
//				else
//				{
//					go.isStatic = true;
//					//Debug.Log(go.name + " is going static");
//				}
//			}
//		}
//		yield return new WaitForSeconds(1);
//		//Debug.Log(allThingsCreated.Count + " all created");
//		allRocks.AddComponent<CombineChildren>();
//		allTrees.AddComponent<CombineChildren>();
//		allVeg.AddComponent<CombineChildren>();
//		
//		allThingsCreated.Clear();
//		
//		ResetButton.isEnabled = true;
//	}
	
	//coroutine heavy process of controlling what gets randomly generated, when. 
	IEnumerator SpacedProcess()
	{	
		allRocks = new GameObject();
		allRocks.name = "AllRocks";
		int rocksCreatedSoFar = 0;

		int rocksPerGroup = 2;
		int numberOfRockGroups = rockCount/2;
		
		while(numberOfRockGroups > 20)
		{
			rocksPerGroup+=2;
			numberOfRockGroups = rockCount/rocksPerGroup;
		}
		
		Debug.Log("Going to make : " + numberOfRockGroups + " groups");
		for (int a = 0; a < numberOfRockGroups; a++) //groups 0 - 5
		{
			for(int i = 0; i < rocksPerGroup; i++) // 0 - 19
			{
				Debug.Log("Make rocks from group : " + a + " and item number is : " + i);
				//CreateRandomObjects(rocks, rockCount, true, false,  allRocks);	
				CreateRandomObject(rocks[ Random.Range(0,rocks.Length) ], true, false, allRocks);
				rocksCreatedSoFar++;
			}
			yield return new WaitForEndOfFrame();
			Debug.Log("processed so far, this message once per group : " + rocksCreatedSoFar);
		}
		Debug.Log("Total processed in all groups : " + rocksCreatedSoFar);
		
		yield return new WaitForEndOfFrame();
		//Trees
		allTrees = new GameObject();
		allTrees.name = "AllTrees";
		int treesCreatedSoFar = 0;
		int treesPerGroup = 2;
		int numberOfTreeGroups =  treeCount/2;
		while(numberOfTreeGroups > 20)
		{
			treesPerGroup+=2;
			numberOfTreeGroups = treeCount / treesPerGroup;
		}
		Debug.Log("Going to make : " + numberOfTreeGroups + " groups");
		for (int a = 0; a < numberOfTreeGroups; a++) //groups 0 - 5
		{
			for(int i = 0; i < treesPerGroup; i++) // 0 - 19
			{
				Debug.Log("Make trees from group : " + a + " and item number is : " + i);
				//CreateRandomObjects(rocks, rockCount, true, false,  allRocks);	
				CreateRandomObject(trees[ Random.Range(0,trees.Length) ], true, true, allTrees);
				treesCreatedSoFar++;
			}
			yield return new WaitForEndOfFrame();
			Debug.Log("processed so far, this message once per group : " + treesCreatedSoFar);
		}
		Debug.Log("Total processed in all groups : " + treesCreatedSoFar);
		yield return new WaitForEndOfFrame();
		
		//Vegetation
		allVeg = new GameObject();
		allVeg.name = "AllVeg";
		int vegCreatedSoFar = 0;
		int vegPerGroup = 0;
		int numberOfVegGroups = vegationCount/2;
		while(numberOfVegGroups > 20)
		{
			vegPerGroup+= 2;
			numberOfVegGroups = vegationCount / vegPerGroup;	
		}
		Debug.Log("Going to make : " + numberOfVegGroups + " groups");
		for (int a = 0; a < numberOfVegGroups; a++) //groups 0 - 5
		{
			for(int i = 0; i < vegPerGroup; i++) // 0 - 19
			{
				Debug.Log("Make vegetation from group : " + a + " and item number is : " + i);
				//CreateRandomObjects(rocks, rockCount, true, false,  allRocks);	
				CreateRandomObject(vegetation[ Random.Range(0,vegetation.Length) ], true, true, allVeg);
				vegCreatedSoFar++;
			}
			yield return new WaitForEndOfFrame();
			Debug.Log("processed so far, this message once per group : " + vegCreatedSoFar);
		}
		Debug.Log("Total processed in all groups : " + vegCreatedSoFar);
		
		yield return new WaitForSeconds(4);
		foreach(GameObject go in allThingsCreated)
		{
			//if(go.GetComponent<Rigidbody>().IsSleeping() == false)
			if(go != null)
			{
				if(!go.GetComponent<RandomlyCreatedObject>().grounded )
				{
					//Debug.Log(go.name + " is not sleeping");
					Destroy(go);
					
				}
				else
				{
					go.isStatic = true;
					//Debug.Log(go.name + " is going static");
				}
			}
		}
		yield return new WaitForSeconds(1);
		//Debug.Log(allThingsCreated.Count + " all created");
//		allRocks.AddComponent<CombineChildren>();
//		allTrees.AddComponent<CombineChildren>();
//		allVeg.AddComponent<CombineChildren>();
	//	SplitAllThingsIntoGroupsAndAddCombineComponent();
		SplitBasedOnVectorQuantity(allRocks);
		SplitBasedOnVectorQuantity(allTrees);
		SplitBasedOnVectorQuantity(allVeg);
		ResetButton.isEnabled = true;
	}
	
//	bool SplitAgain(GameObject go)
//	{
//		int vertexCount = 0;
//		foreach(transform t in go.transform)
//		{
//			//for if mesh is top of hierarchy
//			if( t.gameObject.GetComponent<MeshFilter>())
//			{
//				vertexCount += t.gameObject.GetComponent<MeshFilter>().mesh.vertexCount;
//			}else
//			{
//				foreach(MeshFilter m in t.gameObject.GetComponentsInChildren<MeshFilter>())
//				{
//					vertexCount += t.gameObject.GetComponent<MeshFilter>().mesh.vertexCount;
//				}
//			}
//			if(vertexCount >= 64999)
//			{
//				
//				Debug.Log("Vertex count is over.. " + vertexCount);
//				
//			}
//		}
//		
//		return false;
//	}
	
	void SplitBasedOnVectorQuantity(GameObject go)
	{
		int maxVertCount = 64800;
		int vertexCountForGroup = 0;
		bool thisOneIsUnder = true;

		
		int timesGoneOver = 0;
		int vertexCount = 0;
		GameObject go2 = new GameObject();
		List<GameObject> Combinations = new List<GameObject>();
		foreach(Transform t in go.transform)
		{
			if(t.gameObject.GetComponent<MeshFilter>())
			{
				vertexCount += t.gameObject.GetComponent<MeshFilter>().mesh.vertexCount;
			
			}
			foreach(MeshFilter m in t.gameObject.GetComponentsInChildren<MeshFilter>())
			{
				vertexCount += m.mesh.vertexCount;
			}
			if(vertexCount >= maxVertCount)
			{
				maxVertCount+= maxVertCount;
				Destroy(go2);
				go2 = new GameObject();
				go2.name = go.name+timesGoneOver;
				Debug.Log(go2.name + " is the new CombineHolder, and the new max vert count is : " + maxVertCount);
				thisOneIsUnder = false;
				Combinations.Add(go2);
				timesGoneOver++;
			}
			if(!thisOneIsUnder)
			{
				Debug.Log("Vertex count : " + vertexCount);
				t.parent = go2.transform;
			}//else, do nothing - keep it under the original prefab
		}
		
		//go2.AddComponent<CombineChildren>();
		go.AddComponent<CombineChildren>();
		foreach(GameObject p in Combinations)
		{
			if(p)
			{
				Debug.Log("Adding Combine to : " + p.name);
				p.AddComponent<CombineChildren>();
			}
		}
	}
	
//	//Solves the problem of combining 65,000 meshes
//	void SplitAllThingsIntoGroupsAndAddCombineComponent()
//	{
//		Debug.Log("Splitting things by UV");
//		GameObject[] CombineGroups = new GameObject[1];
//		GameObject CombinationHeirarchy = new GameObject();
//		
//		//Make sure all items have unique names
//		foreach(GameObject go in allThingsCreated)
//		{
//			if(go == null)
//			{
//				break;
//			}
//			Debug.Log("Processing : " + go.name);
//			//check the uvs by name, and move object accordingly
//			//string matName = go.GetComponentInChildren<MeshRenderer>().renderer.material.name;
//			string matName;
//			if(go.renderer)
//			{
//				matName = go.renderer.sharedMaterial.name;
//			
//			}
//			else matName = go.GetComponentInChildren<MeshRenderer>().renderer.sharedMaterial.name;
//		
//			
//			Debug.Log("Material name is : " + matName);
//			//child object - this is where all the meshes with shared meshes will go
//			GameObject ObjectToAddItemsTo = new GameObject();
//			if(!CombineGroups[0])
//			{
//				GameObject starter = new GameObject();
//				CombineGroups[0] = starter;
//				//starter = CombineGroups[0];
//				starter.name = matName;
//			}
//			foreach(GameObject a in CombineGroups)
//			{
//				if(a.name == matName)
//				{
//					ObjectToAddItemsTo = a;
//				}
//			}
//			if(!ObjectToAddItemsTo) //There are no matches. Create a new go, add it to the combine groups, and attach. 
//			{
//				ObjectToAddItemsTo = new GameObject();
//				GameObject.Instantiate(ObjectToAddItemsTo);
//				CombineGroups[CombineGroups.Length] = ObjectToAddItemsTo;
//				go.transform.parent = ObjectToAddItemsTo.transform;
//			}
//			else //there is a match. parent the object
//			{
//				go.transform.parent = ObjectToAddItemsTo.transform;
//			}
//		
//			//if the mesh.verts number more than 65,000, split into another gameobject, then add the component.
//		}
//		
//		foreach(GameObject go in CombineGroups)
//		{
//			if(go == null)
//				break;
//			Debug.Log("Added CombineChildren to " + go.name);
//			go.AddComponent<CombineChildren>();
//		}
//		allThingsCreated.Clear();
//	}
//	
//	void CreateVegetation()
//	{
//		for(int i = 0; i <= numberToSpawn; i++)
//		{
//			GameObject Sphere1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
//			Sphere1.AddComponent<SphereObject>();
//			Sphere1.isStatic = true;
//			Sphere1.transform.parent = transform;
//			Sphere1.AddComponent<NavMeshObstacle>();
//			//Sphere1.AddComponent<Rigidbody>();
//			//Sphere1.renderer.material.mainTexture = textureToApplyForTest;
//			if(i % 2 == 0)
//			Sphere1.renderer.material = materialToApplyForTest[0];
//			else Sphere1.renderer.material = materialToApplyForTest[1];
//			Vector3 random1 = GetARandomPosition();
//			
//			//Check if on navmesh, if not, randomize again
//			
//			Sphere1.transform.position = random1;
//		}
//		
//		
//	}
}
