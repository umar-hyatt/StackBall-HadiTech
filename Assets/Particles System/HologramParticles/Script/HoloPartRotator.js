var speedx = 0.0;
var speedy = 0.0;
var speedz = 0.0;

private var UseCenter = false;

function Start(){
if(UseCenter){transform.position = GetComponent.<Renderer>().bounds.center+transform.position;}
}

function Update() {
transform.Rotate(speedx * Time.deltaTime, speedy * Time.deltaTime, speedz * Time.deltaTime);
//print(transform.position);
}