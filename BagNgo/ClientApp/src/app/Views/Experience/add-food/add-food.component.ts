import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/Services/Auth.service';
import { HttpService } from 'src/app/Services/Http/http.service';
@Component({
  selector: 'app-add-food',
  templateUrl: './add-food.component.html',
  styleUrls: ['./add-food.component.css']
})
export class AddFoodComponent implements OnInit {

  displayFood: boolean;
  @Input('food') food;
  @Output("delete") deleteemit = new EventEmitter()

  constructor(private fb: FormBuilder, private http: HttpService,
    private route: Router,
    private securityService: AuthService) { }
  ngOnInit(): void {
    console.log(this.food);
    
  }
  delete() {
    this.deleteemit.emit()
    this.displayFood = false
  }
  closePrompt() {
    this.displayFood = false;
  }
  deleteImg(index) {
    this.food.FoodImages.splice(index, 1)
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
          if (id == 'ImageFood') {
            this.food.FoodImages.push({ data, file })
          }
        }
      };
      reader.readAsDataURL(file);
    }
  }
}