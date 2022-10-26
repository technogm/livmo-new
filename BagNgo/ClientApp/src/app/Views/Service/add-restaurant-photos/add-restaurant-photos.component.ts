import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-add-restaurant-photos',
  templateUrl: './add-restaurant-photos.component.html',
  styleUrls: ['./add-restaurant-photos.component.css']
})
export class AddRestaurantPhotosComponent implements OnInit {

  @Input('expPicturess') expPicturess = []
  @Output() expPicturessChange = new EventEmitter()
  constructor() { }
  ngOnInit(): void {
    console.log(this.expPicturess)
  }

  clickFakeUpload(id: any) {
    document.getElementById(id).click()
  }
  uploadedFile(e, id) {
    if (e.target.files && e.target.files[0]) {
      const file = e.target.files[0];
      const reader = new FileReader();
      reader.onload = e => {
        let data: any = reader.result
        if (file.type.indexOf('video') != -1) {
        }
        else if (file.type.indexOf('image') != -1) {
          if (id == 'Image') {
            this.expPicturess.push({data,file})
            this.expPicturessChange.emit(this.expPicturess)
          }
        }
      };
      reader.readAsDataURL(file);
    }
  }
  deleteImg(index){
    this.expPicturess.splice(index,1)
  }
}