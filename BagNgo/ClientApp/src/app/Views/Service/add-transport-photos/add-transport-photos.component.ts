import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-add-transport-photos',
  templateUrl: './add-transport-photos.component.html',
  styleUrls: ['./add-transport-photos.component.css']
})
export class AddTransportPhotosComponent implements OnInit {
  @Input('expPictures') expPictures = []
  @Output() expPicturesChange = new EventEmitter()
  constructor() { }
  ngOnInit(): void {
    console.log(this.expPictures)
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
            this.expPictures.push({data,file})
            this.expPicturesChange.emit(this.expPictures)
          }
        }
      };
      reader.readAsDataURL(file);
    }
  }
  deleteImg(index){
    this.expPictures.splice(index,1)
  }
}
