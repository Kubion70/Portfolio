import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormGroupDirective, NgForm } from '@angular/forms';
import { ErrorStateMatcher, MatSnackBar } from '@angular/material';
import { ErrorSnackBarComponent } from '@shared/components/error-snack-bar/error-snack-bar.component';

@Component({
  selector: 'app-contact-form',
  templateUrl: './contact-form.component.html',
  styleUrls: ['./contact-form.component.scss']
})
export class ContactFormComponent implements OnInit {

  contactForm = new FormGroup({
    name: new FormControl('', Validators.required),
    email: new FormControl('', [
      Validators.required,
      Validators.email
    ]),
    subject: new FormControl('', Validators.required),
    details: new FormControl('', Validators.required)
  });

  matcher = new DefaultErrorStateMatcher();

  constructor(private matSnackBar: MatSnackBar) { }

  ngOnInit() {
  }

  onContactFormSubmit(): void {
    if(!this.contactForm.valid) {
      this.matSnackBar.openFromComponent(ErrorSnackBarComponent, {
        data: {
          message: "Contact form has errors. Please check your data and try again."
        }
      });
    }
  }
}

export class DefaultErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const isSubmitted = form && form.submitted;
    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }
}
