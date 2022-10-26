import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/Services/Auth.service';
import { HttpService } from 'src/app/Services/Http/http.service';

@Component({
  selector: 'app-add-lodgingexp',
  templateUrl: './add-lodgingexp.component.html',
  styleUrls: ['./add-lodgingexp.component.css']
})
export class AddLodgingexpComponent implements OnInit {

 
  displayLodging: boolean;
  @Input('lodg') lodg;
  @Output("delete") deleteemit = new EventEmitter()

  constructor(private fb: FormBuilder, private http: HttpService,
    private route: Router,
    private securityService: AuthService) { }
  ngOnInit(): void {
    console.log(this.lodg);
    
  }
  delete() {
    this.deleteemit.emit()
    this.displayLodging = false
  }
  closePrompt() {
    this.displayLodging = false;
  }
  deleteImg(index) {
    this.lodg.LodgingImages.splice(index, 1)
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
          if (id == 'ImageLodging') {
            this.lodg.LodgingImages.push({ data, file })
          }
        }
      };
      reader.readAsDataURL(file);
    }
  }
}