import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ServicesCommercantService } from 'src/app/Services/services-commercant.service';

@Component({
  selector: 'app-home-transport',
  templateUrl: './home-transport.component.html',
  styleUrls: ['./home-transport.component.css']
})
export class HomeTransportComponent implements OnInit {

  statut:any="deslike";
  dataArray:any;
  transportPhotos : any;
  display: boolean = false;
  dataFilter:any=["Where","Whene","People","City","Theme","Sub-Theme","Season","Price min","Price max"];


  constructor(private experienceService: ServicesCommercantService,private router: Router,private activatedRoute : ActivatedRoute) { 
    //this.dataFilter=["Where","Whene","People","City","Theme","Sub-Theme","Season","Price min","Price max"];

    
    let favourites: { [key: string]: boolean } = {};
    //add all id experience in key and value will be false 
    //then make true when click of like 

    
    this.experienceService.getValidTrasports().subscribe(data=>{
     
      this.dataArray=data

       
       console.log("allEx",this.dataArray)
       console.log("ex1",this.dataArray[0])

       for (let i = 0; i < this.dataArray.length; i++) {


        this.experienceService.getTransportPhotosById(this.dataArray[i].transportId).subscribe(
          (reponse: any) => {
            console.log(this.transportPhotos);  
            this.transportPhotos = reponse;
            this.dataArray[i] = { ...this.dataArray[i], img: this.transportPhotos[0] }

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
  this.router.navigate(['aboutTransport', a ]);
}

}