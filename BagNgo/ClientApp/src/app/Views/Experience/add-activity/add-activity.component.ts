import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/Services/Auth.service';
import { HttpService } from 'src/app/Services/Http/http.service';

@Component({
  selector: 'app-add-activity',
  templateUrl: './add-activity.component.html',
  styleUrls: ['./add-activity.component.css']
})
export class AddActivityComponent implements OnInit {
  displayActivity: boolean;
  @Input('activity') activity;
  @Output("delete") deleteemit = new EventEmitter()

  constructor(private fb: FormBuilder, private http: HttpService,
    private route: Router,
    private securityService: AuthService) { }
  ngOnInit(): void {
    console.log(this.activity);
    
  }
  delete() {
    this.deleteemit.emit()
    this.displayActivity = false
  }
  closePrompt() {
    this.displayActivity = false;
  }
  deleteImg(index) {
    this.activity.ActImages.splice(index, 1)
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
            this.activity.ActImages.push({ data, file })
          }
        }
      };
      reader.readAsDataURL(file);
    }
  }
}


