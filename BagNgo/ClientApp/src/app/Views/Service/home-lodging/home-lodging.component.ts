import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CommercantService } from 'src/app/Services/commercant.service';
import { ExperienceService } from 'src/app/Services/experience.service';
import { ServicesCommercantService } from 'src/app/Services/services-commercant.service';

@Component({
  selector: 'app-home-lodging',
  templateUrl: './home-lodging.component.html',
  styleUrls: ['./home-lodging.component.css']
})
export class HomeLodgingComponent implements OnInit {

  statut:any="deslike";
  dataArray:any;
  lodgingPhotos : any;
  display: boolean = false;
  dataFilter:any=["Where","Whene","People","City","Theme","Sub-Theme","Season","Price min","Price max"];


  constructor(private experienceService: ServicesCommercantService,private router: Router,private activatedRoute : ActivatedRoute) { 
    //this.dataFilter=["Where","Whene","People","City","Theme","Sub-Theme","Season","Price min","Price max"];

    
    let favourites: { [key: string]: boolean } = {};
    //add all id experience in key and value will be false 
    //then make true when click of like 

    
    this.experienceService.getValidLodgings().subscribe(data=>{
     
      this.dataArray=data

       
       console.log("allEx",this.dataArray)
       console.log("ex1",this.dataArray[0])

       for (let i = 0; i < this.dataArray.length; i++) {


        this.experienceService.getLodgingPhotosById(this.dataArray[i].lodgingId).subscribe(
          (reponse: any) => {
            console.log(this.lodgingPhotos);  
            this.lodgingPhotos = reponse;
            this.dataArray[i] = { ...this.dataArray[i], img: this.lodgingPhotos[0] }

          })
      }
    })
  }

  ngOnInit(): void {
   

  }
  like(a:any) : void {
    this.statut='like';
    
    
    
  }
  deslike(a:any) : void {
    this.statut='deslike';
    
    
    
  }
  showDialog() {
    this.display = true;
  }

  closeDialog(){
    this.display = false
}
deleteImg(indexx){
  const index: number = this.dataFilter.indexOf(indexx);
if (index !== -1) {
  this.dataFilter.splice(index, 1);
}
console.log(this.dataFilter)
}
goToDetails(a:any) {
  this.router.navigate(['aboutLodging', a ]);
}

}
