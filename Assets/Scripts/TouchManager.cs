using UnityEngine;
public class TouchManager : MonoBehaviour 

{    private int touchCount;    
	private TouchPhase phase;    
	void Update() {        

		// Sauvegarde combien de doigt touchent l'écran        
		touchCount = Input.touchCount;        
		// S'il y a un doigt minimum        
		if (touchCount > 0) {            
			phase = Input.GetTouch(0).phase;           
			StartAction(phase);        }   
	}   


	/// <summary>   
	/// Commencement des actions par rapport au mode du touché   
	/// </summary>   
	/// <param name="p">The touch phase/Le mode du touché</param>    
			
			void StartAction(TouchPhase p) {      
		print(string.Format("Touch phase = {0}", p));       
			switch (p) 
		{            
			case TouchPhase.Began: BeganAction();
			break;            
			case TouchPhase.Canceled: CanceledAction(); 
			break;           
			case TouchPhase.Ended: 	EndedAction(); 
			break;            
			case TouchPhase.Moved: MovedAction(); 
			break;           
			case TouchPhase.Stationary: StationaryAction();
			break;        
		}    
	}  

	void BeganAction() {        
		// Actions quand l'utilisateur commence son touché      
		print("Phase BEGAN detected");    }   
	void CanceledAction() {       

		// Actions quand l'utilisateur a annulé son touché       
		print("Phase CANCELED detected");    }    

	void EndedAction() {      
		// Actions quand l'utilisateur fini son touché       
		print("Phase ENDED detected");    }    

	void MovedAction() {     
		// Actions quand l'utilisateur bouge son touché      
		print("Phase MOVED detected.");    }    

	void StationaryAction() {     
		// Actions quand le touché de l'utilisateur ne bouge plus      
		print("Phase STATIONARY detected.");    
	
	}
}