import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { FormBuilder, FormGroup, Validators, FormControl, } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  @Output() cancelRegister = new EventEmitter();
  registerForm: FormGroup;


  constructor(private authService: AuthService, private fb: FormBuilder ) { }

  ngOnInit() {
    this.createRegisterForm();
  }

  createRegisterForm() {
    this.registerForm = this.fb.group({
      userName: ['', Validators.required, this.userNameTakenValidator],
      email: ['', [Validators.email, Validators.required]],
      isGm: [''],
      isPlayer: [''],
      password: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(8)]],
      confirmPassword: ['', Validators.required]
    }, {validator: this.passwordMatchValidator});
  }
  passwordMatchValidator(g: FormGroup) {
    return g.get('password').value === g.get('confirmPassword').value ? null : {'mismatch': true};
  }

  userNameTakenValidator(g: FormGroup) {
    // const userName = g.get('userName').value();
    // console.log(this.authService.checkUsernameNotTaken(userName));
    console.log(g.get('userName').value);
  }

  cancel() {
    this.cancelRegister.emit(false);
  }
}
