import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MatButtonModule, MatCardModule, MatFormFieldModule, MatInputModule, MatChipsModule, MatSnackBarModule, MatSnackBar } from '@angular/material';
import { MatIconModule } from '@angular/material/icon';
import { MatToolbarModule } from '@angular/material/toolbar';
import { ReactiveFormsModule } from '@angular/forms';
import { ErrorSnackBarComponent, SuccessSnackBarComponent } from './components';

@NgModule({
  declarations: [ErrorSnackBarComponent, SuccessSnackBarComponent],
  imports: [
    CommonModule,
    MatButtonModule,
    MatIconModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatChipsModule,
    MatSnackBarModule,
    ReactiveFormsModule
  ],
  exports: [
    MatButtonModule,
    MatToolbarModule,
    MatIconModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatChipsModule,
    MatSnackBarModule,
    ReactiveFormsModule,
    ErrorSnackBarComponent,
    SuccessSnackBarComponent
  ],
  providers: [
    MatSnackBar
  ]
})
export class SharedModule { }