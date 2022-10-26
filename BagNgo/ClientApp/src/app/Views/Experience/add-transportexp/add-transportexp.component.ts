import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/Services/Auth.service';
import { HttpService } from 'src/app/Services/Http/http.service';

@Component({
  selector: 'app-add-transportexp',
  templateUrl: './add-transportexp.component.html',
  styleUrls: ['./add-transportexp.component.css']
})
export class AddTransportexpComponent implements OnInit {

  displayTransport: boolean;
  @Input('trans') trans;
  @Output("delete") deleteemit = new EventEmitter()

  constructor(private fb: FormBuilder, private http: HttpService,
    private route: Router,
    private securityService: AuthService) { }
  ngOnInit(): void {
    console.log(this.trans);
    
  }
  delete() {
    this.deleteemit.emit()
    this.displayTransport = false
  }
  closePrompt() {
    this.displayTransport = false;
  }
  deleteImg(index) {
    this.trans.TransportImages.splice(index, 1)
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
          if (id == 'ImageTransport') {
            this.trans.TransportImages.push({ data, file })
          }
        }
      };
      reader.readAsDataURL(file);
    }
  }
}