import { Component, Inject, OnInit } from '@angular/core';
import { UntypedFormGroup, UntypedFormBuilder, Validator, Validators } from '@angular/forms';
import { ApiService } from '../services/api.service';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
@Component({
  selector: 'app-dialog',
  templateUrl: './dialog.component.html',
  styleUrls: ['./dialog.component.scss'],
})
export class DialogComponent implements OnInit {
  freshnessList = ['Band New', 'Second Hand', 'Refurbished'];
  productForm!: UntypedFormGroup;
  actionBtn: string = 'Save';
  constructor(
    private formBuilder: UntypedFormBuilder,
    private api: ApiService,
    @Inject(MAT_DIALOG_DATA) public editData: any,
    private dailogRef: MatDialogRef<DialogComponent>,
    private toastr:ToastrService
  ) {}

  ngOnInit(): void {
    this.productForm = this.formBuilder.group({
      productName: ['', Validators.required],
      category: ['', Validators.required],
      freshness: ['', Validators.required],
      price: ['', Validators.required],
      comment: ['', Validators.required],
      date: ['', Validators.required],
    });
    if (this.editData) {
      this.actionBtn = 'Update';
      this.productForm.controls['productName'].setValue(
        this.editData.productName
      );
      this.productForm.controls['category'].setValue(this.editData.category);
      this.productForm.controls['freshness'].setValue(this.editData.freshness);
      this.productForm.controls['price'].setValue(this.editData.price);
      this.productForm.controls['comment'].setValue(this.editData.comment);
      this.productForm.controls['date'].setValue(this.editData.date);
    }
  }
  addProduct() {
    if (!this.editData) {
      if (this.productForm.valid) {
        this.api.postProduct(this.productForm.value).subscribe({
          next: (res) => {
            this.toastr.success('Product added successfully.','Create Product');
            this.productForm.reset();
            this.dailogRef.close('save');
          },
          error: () => {
            this.toastr.error('Error while adding product.','Create Product');
          },
        });
      }
    } else {
      this.updateProduct();
    }
  }
  updateProduct() {
    this.api.putProduct(this.productForm.value, this.editData.id).subscribe({
      next: (res) => {
        this.toastr.success('Product updated successfully.','Update Product');
        this.productForm.reset();
        this.dailogRef.close('update');
      },
      error: () => {
        this.toastr.error('Error while updating product.','Update Product');
      },
    });
  }
}
