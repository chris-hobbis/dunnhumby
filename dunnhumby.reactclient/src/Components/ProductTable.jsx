import React, { useEffect, useState } from 'react';
import axios from 'axios';

const ProductTable = ({ setSelectedProduct, reload }) => {

    const [products, setProducts] = useState([]);

    useEffect(() => {
        const fetchProducts = async () => {
            try {
                const response = await axios.get('http://localhost:5179/products');
                console.log(response);
                setProducts(response.data);
            } catch (error) {
                console.error('Error fetching products:', error);
            }
        };

        fetchProducts();
    }, [reload]);

    const handleRowClick = (product) => {
        setSelectedProduct(product);
    };

    return (
        <div>
            <table className="table table-bordered">
                <thead>
                <tr>
                    <th>Name</th>
                    <th>Code</th>
                    <th>Price</th>
                    <th>SKU</th>
                    <th>Stock qty.</th>
                    <th>Date added</th>
                </tr>
                </thead>
                <tbody>
                {products.length > 0 ? (
                    products.map((product) => (
                        <tr key={product.id} onClick={() => handleRowClick(product)} style={{ cursor: 'pointer' }}>
                            <td>{product.name}
                                <div className="text-muted" style={{ fontSize: '0.8em'}}>{product.category.name}</div>
                            </td>
                            <td>{product.code}</td>
                            <td>{product.price}</td>
                            <td>{product.sku}</td>
                            <td>{product.stock}</td>
                            <td>{product.dateAddedFormatted}</td>
                        </tr>
                    ))
                ) : (
                    <tr>
                        <td colSpan="3" style={{ textAlign: "center", padding: "10px" }}>
                            No results found
                        </td>
                    </tr>
                )}
                </tbody>
            </table>
        </div>
    );
};

export default ProductTable;
