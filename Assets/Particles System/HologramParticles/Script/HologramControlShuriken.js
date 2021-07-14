//This code can be used for private or commercial projects but cannot be sold or redistributed without written permission.
//Copyright Nik W. Kraus / Dark Cube Entertainment LLC. 

#pragma strict
@script RequireComponent(ParticleSystem);

var Enable = true;
@Range (0.0, 0.2)
var JitterAmount = 0.0;

@Range (0.1, 8.0)
var ParticleSpeed = .5;

@Range (1, 2000)
var ParticleRate = 100;
var UseRandomColor = false;

@Tooltip ("When on particles do not die. When off, particle system life setting is used. Turn off to use Evap or Dissolve.")
var ParticleStatic = true;

enum ParticleEnd { Dissolve, Evap}
@Tooltip ("Turn off Particle Static to use End type")
var ParticleEndType : ParticleEnd;
var EvapDir = Vector3(0.0,0.2,0.0);

private var CreateMesh : Mesh;

var UseWayPoints = false;
var WaypointTag = "WayPoint";
private var WayPoints : GameObject[];

var SourceMeshObject : Mesh;

@Tooltip ("Position that particles gather in world space. If none assigned position default is this object.")
var GatherPos : Transform;
private var GatherT : Vector3;
private var GatherR : Quaternion;

@Tooltip ("Used to scale the mesh if needed. 1 = default mesh scale")
var GatherScale = 1.0;

private var PartSystem : ParticleSystem;
private var particles : ParticleSystem.Particle[];
private var Partdist : float;
private var TotalPart : int;

private var CheckTimer = 0.0;
private var Timer = .3;

private var newVertices : Vector3[];
private var newUV : Vector2[];
private var newTriangles : int[];
private var xx : int;
private var PosP : Vector3;

@Range (.01, 1.0)
var PreviewCubeSize = .1;

////////////////////////////////////////////
function Start (){	
	PartSystem = gameObject.GetComponent("ParticleSystem");
	PartSystem.startSpeed = 0;
	
	CheckTimer = Time.time;
	
	///this is to help fix a Unity particle render issue
	gameObject.transform.localScale = Vector3(3,3,3);
	
	if(UseWayPoints){
		WayPoints = GameObject.FindGameObjectsWithTag(WaypointTag) as GameObject[];
		newVertices = new Vector3[WayPoints.Length];
			if(WayPoints.Length > 0){
				for(var xx = 0; xx < WayPoints.Length; xx++){
					newVertices[xx] = WayPoints[xx].transform.position;
				}
			}
		else{
			Debug.Log("No transform objects have waypoint tag assigned. Please assign them.");
		}
	}
	else{
		if(SourceMeshObject){
			newVertices = SourceMeshObject.vertices;
		}		
		else{
			Debug.Log("No Mesh assigned, please assign one.");
		}
		
	}
	
	///Gather position
	if(GatherPos){
		GatherT = GatherPos.position;
		GatherR = GatherPos.rotation;
	}
	else{
		GatherT = gameObject.transform.position;
		GatherR = gameObject.transform.rotation;
		Debug.Log("No Gather Position transform assigned, this game object position will be used by default.");
	}
	
	//Model Vertex density check
	if(newVertices.Length > 9000){
		Debug.Log("Number of Verts is " + newVertices.Length + " ... suggest assigning a less complex model.");
	}
	
	particles = new ParticleSystem.Particle[PartSystem.particleCount];
	PartSystem.maxParticles = newVertices.Length;	

}///End Start




function LateUpdate() {
	
	if(SourceMeshObject && !UseWayPoints){
		newVertices = SourceMeshObject.vertices;
	}		
		
	if(GatherPos){
		GatherT = GatherPos.position;
		GatherR = GatherPos.rotation;
	}
	else{
		GatherT = gameObject.transform.position;
		GatherR = gameObject.transform.rotation;
	}	
		
	
	particles = new ParticleSystem.Particle[PartSystem.particleCount];
	TotalPart = PartSystem.GetParticles(particles);
	
	//Particle settings
	PartSystem.emissionRate = ParticleRate;
	PartSystem.maxParticles = newVertices.Length;
		
	///Check for waypoints
	if(UseWayPoints){
		GatherT = Vector3.zero;
		GatherScale = 1.0;
		if(WayPoints.Length > 0){
			for(var xx = 0; xx < WayPoints.Length; xx++){
				newVertices[xx] = WayPoints[xx].transform.position;
			}
		}
	}	
	

		
	//Loop through particles
		for(var i = 0; i < TotalPart; i++){
				if(Enable){					
					var PartAge = (particles[i].startLifetime - particles[i].lifetime)/particles[i].startLifetime;
					
					if(ParticleStatic){
						particles[i].lifetime = 5;
					}
							
					if(JitterAmount > 0){
						particles[i].position += Vector3(Random.Range(-JitterAmount,JitterAmount),Random.Range(-JitterAmount,JitterAmount),Random.Range(-JitterAmount,JitterAmount)) * Mathf.Sin(Time.time);
					}
					
					if(UseWayPoints){
						PosP = WayPoints[i].transform.position;
					}
					else{
						if(newVertices.Length >= TotalPart){
							PosP = (GatherR*newVertices[i]+GatherT*0);
						}
						else{
							PosP = GatherT;
						}
					}
					
					if(UseRandomColor){
						if(Random.Range(0,TotalPart) == i){
							particles[i].color = Color(Random.Range(0.0,1.0),Random.Range(0.0,1.0),Random.Range(0.0,1.0),1);
						}
					}
					
					if(!ParticleStatic){
						if(ParticleEndType == ParticleEndType.Evap){
							if(PartAge > particles[i].lifetime-.5){								
								particles[i].position = Vector3.Lerp(particles[i].position, particles[i].position + EvapDir, Time.smoothDeltaTime*ParticleSpeed);
							}
							else{
								particles[i].position = Vector3.Lerp(particles[i].position, Vector3(PosP.x*GatherScale,PosP.y*GatherScale,PosP.z*GatherScale) + GatherT, Time.smoothDeltaTime*ParticleSpeed);
							}							
						}
						else if(ParticleEndType == ParticleEndType.Dissolve){
							particles[i].lifetime = particles[i].lifetime-Random.Range(.01,.1);
							particles[i].position = Vector3.Lerp(particles[i].position, Vector3(PosP.x*GatherScale,PosP.y*GatherScale,PosP.z*GatherScale) + GatherT, Time.smoothDeltaTime*ParticleSpeed);
						}
						else{
							particles[i].position = Vector3.Lerp(particles[i].position, Vector3(PosP.x*GatherScale,PosP.y*GatherScale,PosP.z*GatherScale) + GatherT, Time.smoothDeltaTime*ParticleSpeed);
						}
					}
					else{
						particles[i].position = Vector3.Lerp(particles[i].position, Vector3(PosP.x*GatherScale,PosP.y*GatherScale,PosP.z*GatherScale) + GatherT, Time.smoothDeltaTime*ParticleSpeed);
					}
		}/////End Enable
		else{
			if(!ParticleStatic && ParticleEndType == ParticleEndType.Dissolve){
				particles[i].lifetime = particles[i].lifetime-.5;
			}
			else if(!ParticleStatic && ParticleEndType == ParticleEndType.Evap){
				particles[i].lifetime = Mathf.Lerp(particles[i].lifetime,0.0,.1);
			}
		}
	}////end loop
	
	PartSystem.SetParticles(particles, particles.Length);
	
} ///////End Update



private var WayPointFlag = true;

///Draw gizmos
function OnDrawGizmosSelected(){
	
	if(UseWayPoints){
		WayPoints = GameObject.FindGameObjectsWithTag(WaypointTag) as GameObject[];
		if(WayPoints.Length > 0){
		WayPointFlag = true;	
			for(var t = 0; t < WayPoints.Length; t++){
				Gizmos.color = Color (1,0,0,.5);
				Gizmos.DrawCube(WayPoints[t].transform.position, Vector3.one*PreviewCubeSize);
				Gizmos.color = Color (1,1,1,.5);
				Gizmos.DrawWireSphere (WayPoints[t].transform.position, .1);
			}
		}
		else{
			if(WayPointFlag){
				WayPointFlag = false;
				Debug.Log("No transform objects have waypoint tag assigned. Please assign them.");
			}
		}
	}
	else{
		if(SourceMeshObject && !UseWayPoints){
			WayPointFlag = true;
			if(GatherPos){
				GatherT = GatherPos.position;
				GatherR = GatherPos.rotation;
			}
			else{
				GatherT = gameObject.transform.position;
				GatherR = gameObject.transform.rotation;
			}
			
			Gizmos.color = Color (1,0,0,.3);
			
			newVertices = SourceMeshObject.vertices;
			
			for(var ii = 0; ii < newVertices.Length; ii++){
				var PosP2 = (GatherR*newVertices[ii]+GatherT*0);
				Gizmos.DrawCube (Vector3(PosP2.x*GatherScale,PosP2.y*GatherScale,PosP2.z*GatherScale) + GatherT, Vector3.one*PreviewCubeSize);
			}	
		}
	}///end else
	
	//This is to fix a render issue with Unity particle system
	if(transform.childCount > 0){
		Debug.Log("Hologram System cannot have child objects they have been auto moved up one level.");
		for(var ix = 0;ix <= transform.childCount; ix ++) {
	 		if(gameObject.transform.parent){
	 			transform.GetChild(ix).gameObject.transform.parent = gameObject.transform.parent;
	 		}
	 		else{
	 			gameObject.transform.DetachChildren();
	 		}
	 	}
	}
}
