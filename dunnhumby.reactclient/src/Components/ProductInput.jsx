import React, { useState } from 'react';
import axios from 'axios';

const ProductInput = ({ categories, onProductCreated }) => {
    const [product, setProduct] = useState({
        name: '',
        price: '',
        code: '',
        sku: '',
        stock: '',
        categoryId: ''
    });

    const handleChange = (e) => {
        const { name, value } = e.target;
        setProduct({ ...product, [name]: value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            await axios.post('http://localhost:5179/products', product);
            setProduct({ name: '', price: '', categoryId: '' });
            if (onProductCreated) onProductCreated();
        } catch (error) {
            console.error('Error creating product:', error);
        }
    };

    return (
        <div style={{ maxWidth: '400px' }}>
            <form onSubmit={handleSubmit} className="product-form">

                <div className="mb-3">
                    <label className="form-label fw-bold">Name:</label>
                    <input
                        className="form-control"
                        type="text"
                        name="name"
                        value={product.name}
                        onChange={handleChange}
                        required
                    />
                </div>
                <div className="mb-3">
                    <label className="form-label fw-bold">Category:</label>
                    <select className="form-control" name="categoryId" value={product.categoryId} onChange={handleChange} required>
                        <option value="">Select a category</option>
                        {categories.map((category) => (
                            <option key={category.id} value={category.id}>
                                {category.name}
                            </option>
                        ))}
                    </select>
                </div>
                <div className="mb-3">
                    <label className="form-label fw-bold">Price:</label>
                    <input
                        className="form-control"
                        type="number"
                        name="price"
                        value={product.price}
                        onChange={handleChange}
                        required
                    />
                </div>
                <div className="mb-3">
                    <label className="form-label fw-bold">Code:</label>
                    <input
                        className="form-control"
                        type="text"
                        name="code"
                        value={product.code}
                        onChange={handleChange}
                        required
                    />
                </div>
                <div className="mb-3">
                    <label className="form-label fw-bold">SKU:</label>
                    <input
                        className="form-control"
                        type="text"
                        name="sku"
                        value={product.sku}
                        onChange={handleChange}
                        required
                    />
                </div>
                <div className="mb-3">
                    <label className="form-label fw-bold">Stock:</label>
                    <input
                        className="form-control"
                        type="number"
                        name="stock"
                        value={product.stock}
                        onChange={handleChange}
                        required
                    />
                </div>
                <button type="submit" className="mt-4 btn btn-primary">Create</button>
            </form>
        </div>
    );
};

export default ProductInput;
