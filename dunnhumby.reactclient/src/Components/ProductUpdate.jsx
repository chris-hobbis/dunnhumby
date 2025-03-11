import React, { useState, useEffect } from 'react';
import axios from 'axios';

const ProductUpdate = ({ categories, product, onProductUpdated }) => {
    const [input, setInput] = useState({
        id: '',
        name: '',
        price: ''
    });

    useEffect(() => {
        if (product) {
            setInput({
                id: product.id,
                name: product.name,
                price: product.price,
                code: product.code,
                sku: product.sku,
                stock: product.stock,
                categoryId: product.categoryId
            });
        }
    }, [product]);

    const handleChange = (e) => {
        const { name, value } = e.target;
        setInput((prev) => ({
            ...prev,
            [name]: value
        }));
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        if (!input.id) return;

        try {
            await axios.put(`http://localhost:5179/products/${input.id}`, input);
            if (onProductUpdated) {
                onProductUpdated();
            }
        } catch (error) {
            console.error('Error updating product:', error);
        }
    };

    if (!product) {
        return <p>Select a product to update</p>;
    }

    return (
        <div>
            <form onSubmit={handleSubmit}>
                <input type="hidden" name="id" value={input.id} />
                <div className="mb-3">
                    <label className="form-label fw-bold">Name:</label>
                    <input
                        className="form-control"
                        type="text"
                        name="name"
                        value={input.name}
                        onChange={handleChange}
                        required
                    />
                </div>
                <div className="mb-3">
                    <label className="form-label fw-bold">Category:</label>
                    <select className="form-control" name="categoryId" value={input.categoryId} onChange={handleChange} required>
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
                        value={input.price}
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
                        value={input.code}
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
                        value={input.sku}
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
                        value={input.stock}
                        onChange={handleChange}
                        required
                    />
                </div>
                <button type="submit" className="btn btn-primary">Update</button>
            </form>
        </div>
    );
};

export default ProductUpdate;
